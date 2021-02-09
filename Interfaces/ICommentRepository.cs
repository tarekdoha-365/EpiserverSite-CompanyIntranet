using EPiServer.Core;
using EPiServer.Data;
using EPiServer.Data.Dynamic;
using EpiserverSite_CompanyIntranet.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiserverSite_CompanyIntranet.Interfaces
{
    public interface ICommentRepository
    {
        Comment GetComment(Guid commentId);
        Identity Update(Comment comment)
        void Delete(Guid comment);
        List<Comment> GetCommentList();
    }
}
