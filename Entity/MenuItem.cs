using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite_CompanyIntranet.Entity
{
    public class MenuItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public List<MenuItem> MenuItemList { get; set; }
    }
}