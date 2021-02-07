using EPiServer.Core;
using EPiServer.Data.Dynamic;
using EpiserverSite_CompanyIntranet.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiserverSite_CompanyIntranet.Interface
{
    public interface IComments
    {
        //DynamicDataStore GetStore();
        void Save();
        void Delete(Comment comment);
        IEnumerable<Comment> GetComments();
    }
}
