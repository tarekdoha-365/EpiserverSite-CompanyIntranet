using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EpiserverSite_CompanyIntranet.Business;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Models.Pages
{
    [ContentType(DisplayName = "AboutPageType", GUID = "3fa70028-261b-4001-8989-62ccf03d5761", Description = "")]
    public class AboutPageType : SitePageData
    {
        [CultureSpecific]
        [Display(
                   Name = "Main body",
                   Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                   GroupName = SiteTabNames.Metadata,
                   Order = 500)]
        public virtual XhtmlString MainBody { get; set; }
    }
}