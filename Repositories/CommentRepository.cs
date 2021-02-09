using EPiServer.Core;
using EPiServer.Data;
using EPiServer.Data.Dynamic;
using EpiserverSite_CompanyIntranet.Interface;
using EpiserverSite_CompanyIntranet.EntitiesDTO;
using EpiserverSite_CompanyIntranet.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite_CompanyIntranet
{
    public class CommentRepository : ICommentRepository
    {
        public readonly DynamicDataStore _commentStore;

        public CommentRepository()
        {
            _commentStore = DynamicDataStoreFactory.Instance.CreateStore(typeof(Comment));
        }

        public Comment GetComment(Guid commentId)
        {
            return _commentStore.Load<Comment>(commentId);
        }

        public Identity Save(Comment comment)
        {
            comment.Time = DateTime.UtcNow;
            return _commentStore.Save(comment);
        }

        public void Delete(Guid commentId)
        {
            _commentStore.Delete(commentId);
        }

        public List<Comment> GetCommentList()
        {
            return _commentStore.Items<Comment>().ToList();
        }
    }
}