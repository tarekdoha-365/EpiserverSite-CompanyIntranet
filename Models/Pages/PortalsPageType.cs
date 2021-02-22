using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EpiserverSite_CompanyIntranet.Business;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Models.Pages
{
    [ContentType(DisplayName = "PortalsPageType", GUID = "6b9dabd9-7642-445a-8dc4-eec702ab5157", Description = "")]
    public class PortalsPageType : SitePageData
    {
        [CultureSpecific]
        [Display(
                   Name = "Main body",
                   Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                   GroupName = SiteTabNames.Metadata,
                   Order = 590)]
        public virtual XhtmlString MainBody { get; set; }
    }
}