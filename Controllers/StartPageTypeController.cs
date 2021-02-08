using EPiServer;
using EPiServer.Core;
using EPiServer.Data.Dynamic;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EpiserverSite_CompanyIntranet.Interface;
using EpiserverSite_CompanyIntranet.Models;
using EpiserverSite_CompanyIntranet.Models.Entities;
using EpiserverSite_CompanyIntranet.Models.Pages;
using EpiserverSite_CompanyIntranet.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EpiserverSite_CompanyIntranet.Controllers
{
    public class StartPageTypeController : PageController<StartPageType>
    {
        public ActionResult Index(StartPageType currentPage)
        {
            DynamicDataStore store = typeof(PageViewsData).GetOrCreateStore();
            var viewData = new PageViewsData
            {
                PageId = currentPage.ContentLink.ID,
                ViewsAmount = 1
            };
            store.Save(viewData);

            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            return View(currentPage);
        }
    }
}