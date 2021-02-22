using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EpiserverSite_CompanyIntranet.Business;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EpiserverSite_CompanyIntranet.Models.Pages
{
    [ContentType(DisplayName = "StartPageType", GUID = "1bb6d290-ad32-4e27-9905-e270b5a74543", Description = "")]
    public class StartPageType : SitePageData
    {
        [Display(
            Name = "Search Page",
            Description = "",
            GroupName = SiteTabNames.SiteOptions,
            Order = 1000)]
        public virtual PageReference SearchPage { get; set; }

    }
}