using EpiserverSite_CompanyIntranet.Interfaces;
using System;
using System.Web.Http;
using EpiserverSite_CompanyIntranet.EntitiesDTO;
using System.Collections.Generic;
using EPiServer.Data;
using EPiServer.Web.Mvc;
using StackExchange.Redis;
using System.Runtime.Caching;
using System.Web;
using EPiServer;
using Microsoft.Extensions.Caching.Memory;
using EPiServer.Logging.Compatibility;

namespace EpiserverSite_CompanyIntranet.Controllers.API
{
    [ContentOutputCache]
    [RoutePrefix("api/Comment")]
    
    public class CommentController : ApiController
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ILog Logger = LogManager.GetLogger("CustomLogAppender");

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [Route("Get/{commentId}")]
        [HttpGet]
        public Comment Get(Guid commentId)
        {
            return _commentRepository.Get(commentId);
        }

        [Route("Add")]
        [HttpPost]
        public Identity Add(Comment comment)
        {
            return _commentRepository.Add(comment);
        }

        [Route("Update")]
        [HttpPut]
        public Identity Update(Comment comment)
        {
            return _commentRepository.Update(comment);
        }

        [Route("Delete/{commentId}")]
        [HttpDelete]
        public void DeleteComment(Guid commentId)
        {
            _commentRepository.Delete(commentId);
        }
        [System.Web.Mvc.OutputCache(Duration = 10, VaryByParam = "none")]
        [Route("GetAll")]
        [HttpGet]
        public List<Comment> GetAll()
        {
            Logger.Info("Log In New Text File");
            List<Comment> comments = new List<Comment>();
            var cache = MemoryCache.Default;
           comments = (List<Comment>) cache.Get("comments");
            if (comments == null)
            {
                SetResposneHeaders();
                comments = new List<Comment>();
                System.Diagnostics.Debug.WriteLine("Comments were not in cache"+DateTime.Now);
                //Add to cash
                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTime.Now.AddMinutes(1);
                cache.Set("comments", comments, policy);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Comments were in the cache" + DateTime.Now);
            }
            return _commentRepository.GetAll();
        }
        public void SetResposneHeaders()
        {
            HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddMinutes(2.0));
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Public);
            HttpContext.Current.Response.Cache.SetValidUntilExpires(true);
        }
    }
}