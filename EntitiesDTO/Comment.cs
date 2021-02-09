using EPiServer.Data;
using EPiServer.Data.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite_CompanyIntranet.EntitiesDTO
{
    public class Comment : IDynamicData
    {
        public Identity Id { get; set; }
        public DateTime Time { get; set; }
        public int PageID { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
    }
}