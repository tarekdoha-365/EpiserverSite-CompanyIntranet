using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EpiserverSite_CompanyIntranet.Attributes;
using EpiserverSite_CompanyIntranet.Business;
using EpiserverSite_CompanyIntranet.Enums;
using EpiserverSite_CompanyIntranet.Models.Pages.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Models.Pages
{
    [ContentIcon(ContentIcon.Mail, ContentIconColor.Default)]
    [AvailableContentTypes(Availability.None)]
    [ContentType(DisplayName = "ContactPageType", GUID = "950e2f82-3ee9-450f-88c9-4502598b5a64", Description = "")]
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