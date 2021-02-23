using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EpiserverSite_CompanyIntranet.Models.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EpiserverSite_CompanyIntranet.Controllers
{
    public class ContactPageTypeController : PageController<ContactPageType>
    {
        public ActionResult Index(ContactPageType currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            return View(currentPage);
        }
    }
}