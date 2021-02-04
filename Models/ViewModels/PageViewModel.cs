﻿using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite_CompanyIntranet.Models.ViewModels
{
    public class PageViewModel<T> where T: PageData
    {
        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }
        public T CurrentPage { get; set; }
    }
    public static class PageViewModel
    {
        public static PageViewModel<T> Create<T>(T Page) where T: PageData
        {
            return new PageViewModel<T>(Page);
        }
    }
}