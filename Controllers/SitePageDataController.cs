using EPiServer.Web.Mvc;
using EpiserverSite_CompanyIntranet.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpiserverSite_CompanyIntranet.Controllers
{
    public class SitePageDataController : Controller
    {
        // GET: SitePageData
        public ActionResult Index()
        {
            return View();
        }
    }
}