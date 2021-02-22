using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EpiserverSite_CompanyIntranet.Business;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Models.Pages
{
    [ContentType(DisplayName = "ContactPageType", GUID = "4e838c59-eb05-4d26-9dbb-8f7610d1a7e7", Description = "")]
    public class ContactPageType : SitePageData
    {
        [CultureSpecific]
        [Display(
             Name = "Main body",
             Description = "",
             GroupName = SiteTabNames.Metadata,
             Order = 1000)]
        public virtual XhtmlString Mainbody { get; set; }

    }
}