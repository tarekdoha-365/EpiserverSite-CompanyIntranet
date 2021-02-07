using EPiServer.Core;
using EPiServer.Data.Dynamic;
using EpiserverSite_CompanyIntranet.Interface;
using EpiserverSite_CompanyIntranet.Models.Entities;
using EpiserverSite_CompanyIntranet.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite_CompanyIntranet.Models
{
    public class DDStoreRepository: IComments
    {
        public void Save()
        {
            var store = DynamicDataStoreFactory.Instance.CreateStore(typeof(Comment));
            Comment comment = new Comment();
            store.Save(comment);
        }
        public void Delete(Comment comment)
        {
            var store = DynamicDataStoreFactory.Instance.CreateStore(typeof(Comment));
            store.Delete(comment.Id);
        }

        public IEnumerable<Comment> GetComments()
        {
            throw new NotImplementedException();
        }
    }
}