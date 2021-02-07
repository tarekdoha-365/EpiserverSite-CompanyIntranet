using EPiServer.Data;
using EPiServer.Data.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite_CompanyIntranet.Models.Entities
{
    public class Comment : IDynamicData
    {
        public Comment()
        {
            Initialize();
        }
        public Comment(int pageId, string username, string text)
        {
            Initialize();
            PageID = pageId;
            Username = username;
            Text = text;
        }
        public Identity Id { get; set; }
        public DateTime Time { get; set; }
        public int PageID { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        protected void Initialize()
        {
            Id = Identity.NewIdentity(Guid.NewGuid());
            Time = DateTime.Now;
            Username = string.Empty;
            Text = string.Empty;
        }
    }
}