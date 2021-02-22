using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EpiserverSite_CompanyIntranet.Interfaces;
using EpiserverSite_CompanyIntranet.Models.Pages;
using EpiserverSite_CompanyIntranet.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EpiserverSite_CompanyIntranet.Controllers
{
    public class SearchPageTypeController : PageController<SearchPageType>
    {
        private readonly IMenuService _menuService;
        public SearchPageTypeController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        public ActionResult Index(SearchPageType currentPage)
        {
            var pageViewModel = new SearchPageViewModel()
            {
                CurrentPage = currentPage,
                TopMenu = _menuService.GetTopMenu()
                
            };

            return View(pageViewModel);
        }
    }
}