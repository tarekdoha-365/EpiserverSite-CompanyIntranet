using EpiserverSite_CompanyIntranet.Interface;
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
        [Route("GetComment/{commentId}")]
        public Comment GetComment(Guid commentId)
        {
            return _commentRepository.GetComment(commentId);
        }

        [Route("SaveComment")]
        public Identity SaveComment(Comment comment)
        {
            return _commentRepository.Save(comment);
        }

        [Route("DeleteComment/{commentId}")]
        public void DeleteComment(Guid commentId)
        {
            _commentRepository.Delete(commentId);
        }

        [Route("GetCommentList")]
        public List<Comment> GetCommentList()
        {
            return _commentRepository.GetCommentList();
        }
    }
}