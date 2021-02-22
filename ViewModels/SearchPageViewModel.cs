using EpiserverSite_CompanyIntranet.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite_CompanyIntranet.ViewModels
{
    public class SearchPageViewModel: PageViewModel
    {
        public SearchPageType CurrentPage { get; set; }
    }
}