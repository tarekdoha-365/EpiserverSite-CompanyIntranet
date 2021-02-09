using EpiserverSite_CompanyIntranet.Interfaces;
using System;
using System.Web.Http;
using EpiserverSite_CompanyIntranet.EntitiesDTO;
using System.Collections.Generic;
using EPiServer.Data;

namespace EpiserverSite_CompanyIntranet.Controllers
{
    [RoutePrefix("api/Comment")]
    
    public class CommentController : ApiController
    {
        private readonly ICommentRepository _commentRepository;
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

        [Route("GetAll")]
        [HttpGet]
        public List<Comment> GetAll()
        {
            return _commentRepository.GetAll();
        }
    }
}