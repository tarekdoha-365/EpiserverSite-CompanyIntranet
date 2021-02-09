using EPiServer.Web.Mvc;
using EpiserverSite_CompanyIntranet.Models.Pages;
using System.Web.Mvc;

namespace EpiserverSite_CompanyIntranet.Controllers
{
    public class StartPageTypeController : PageController<StartPageType>
    {
        public ActionResult Index(StartPageType currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            return View(currentPage);
        }
    }
}