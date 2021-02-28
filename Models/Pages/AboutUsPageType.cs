using EpiserverSite_CompanyIntranet.Attributes;
using EpiserverSite_CompanyIntranet.Business;
using EpiserverSite_CompanyIntranet.Enums;
using EpiserverSite_CompanyIntranet.Models.Pages.Base;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Models.Pages
{
    [ContentIcon(ContentIcon.Users, ContentIconColor.Default)]
    [AvailableContentTypes(Availability.None)]
    [ContentType(DisplayName = "AboutUsPageType", GUID = "a3bd6dea-3f9a-4e93-9081-2350c81dc2e7", Description = "")]
    public class AboutUsPageType : SitePageData
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