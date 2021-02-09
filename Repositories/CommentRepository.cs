using EPiServer.Data;
using EPiServer.Data.Dynamic;
using EpiserverSite_CompanyIntranet.Interfaces;
using EpiserverSite_CompanyIntranet.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EpiserverSite_CompanyIntranet
{
    public class CommentRepository : ICommentRepository
    {
        public readonly DynamicDataStore _commentStore;

        public CommentRepository()
        {
            _commentStore = DynamicDataStoreFactory.Instance.CreateStore(typeof(Comment));
        }

        public Comment Get(Guid commentId)
        {
            return _commentStore.Load<Comment>(commentId);
        }

        public Identity Add(Comment comment)
        {
            comment.Time = DateTime.UtcNow;
            return _commentStore.Save(comment);
        }

        public Identity Update(Comment comment)
        {
            var existingComment = _commentStore.Items<Comment>().Where(x => x.Id.Equals(comment.Id)).FirstOrDefault();
            if (existingComment != null)
            {
                existingComment.Time = DateTime.UtcNow;
                existingComment.Text = comment.Text;
                return _commentStore.Save(existingComment);
            }
            throw new Exception("Comment could not be found");
        }
        public void Delete(Guid commentId)
        {
            _commentStore.Delete(commentId);
        }

        public List<Comment> GetAll()
        {
            return _commentStore.Items<Comment>().ToList();
        }
    }
}