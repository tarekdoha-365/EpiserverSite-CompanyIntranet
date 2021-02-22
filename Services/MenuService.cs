using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EpiserverSite_CompanyIntranet.Entities;
using EpiserverSite_CompanyIntranet.Interfaces;
using EpiserverSite_CompanyIntranet.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite_CompanyIntranet.Services
{
    public class MenuService:IMenuService
    {
        public readonly IContentRepository _contentRepository;
        
        public MenuService(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public List<MenuItem> GetTopMenu()
        {
            var startPage= _contentRepository.Get<StartPageType>(ContentReference.StartPage);
            return GetChildren(startPage);
        }

        public List<MenuItem> GetChildren(PageData page)
        {
            var children = new List<MenuItem>();
            var pageChildren = FilterForVisitor.Filter(_contentRepository.GetChildren<PageData>(page.ContentLink));
            foreach(PageData pageChild in pageChildren)
            {
                children.Add(GetMenuItem(pageChild));
            }
            return children;
        }

        public MenuItem GetMenuItem(PageData page)
        {
            return new MenuItem
            {
                Title = page.Name,
                Url= page.LinkURL,
                MenuItemList= GetChildren(page) 
            };
        }
    }
}