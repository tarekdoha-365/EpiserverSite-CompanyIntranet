using EPiServer.Data;
using EPiServer.Data.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite_CompanyIntranet.Models.Entities
{
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true)]
    public class PageViewsData
    {
        public Identity Id { get; set; }

        [EPiServerDataIndex]
        public int PageId { get; set; }

        public int ViewsAmount { get; set; }
    }
}