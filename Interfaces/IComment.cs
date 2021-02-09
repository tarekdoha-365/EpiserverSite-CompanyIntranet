using EPiServer.Core;
using EPiServer.Data;
using EPiServer.Data.Dynamic;
using EpiserverSite_CompanyIntranet.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiserverSite_CompanyIntranet.Interfaces
{
    public interface ICommentRepository
    {
        //DynamicDataStore GetStore();
        Comment Get(Guid commentId);
        Identity Add(Comment comment);
        Identity Update(Comment comment);
        void Delete(Guid comment);
        List<Comment> GetAll();
    }
}
