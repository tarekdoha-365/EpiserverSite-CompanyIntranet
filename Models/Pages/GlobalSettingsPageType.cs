using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EpiserverSite_CompanyIntranet.Attributes;
using EpiserverSite_CompanyIntranet.Business;
using EpiserverSite_CompanyIntranet.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Models.Pages
{
    [ContentIcon(ContentIcon.Settings)]
    [AvailableContentTypes(Availability.None)]
    [ContentType(DisplayName = "GlobalSettingsPageType", GUID = "d74b2d26-345c-46e9-8d68-27a9911001a3", Description = "")]
    public class GlobalSettingsPageType : PageData
    {
        [Display(
           Name = "Search Page Reference",
           Description = "Reference to the Search Page",
           GroupName = SiteTabNames.SiteOptions,
           Order = 10)]
        [AllowedTypes(new[] { typeof(SearchPageType) })]
        public virtual PageReference SearchPageReference { get; set; }

        [Display(
            Name = "About Us Page Reference",
            Description = "Reference to the About Us Page",
            GroupName = SiteTabNames.SiteOptions,
            Order = 10)]
        [AllowedTypes(new[] { typeof(AboutUsPageType) })]
        public virtual PageReference AboutUsPageReference { get; set; }

        [Display(
            Name = "Contact Page Reference",
            Description = "Reference to the Contact Page",
            GroupName = SiteTabNames.SiteOptions,
            Order = 10)]
        [AllowedTypes(new[] { typeof(ContactPageType) })]
        public virtual PageReference ContactPageReference { get; set; }

        [Display(
            Name = "News Page Container Reference",
            Description = "Reference to the News Page Container",
            GroupName = SiteTabNames.SiteOptions,
            Order = 20)]
        [AllowedTypes(new[] { typeof(NewsContainerPageType) })]
        public virtual PageReference NewsPageContainerReference { get; set; }

        [Display(
            Name = "Events Page Container Reference",
            Description = "Reference to the Events Page Container",
            GroupName = SiteTabNames.SiteOptions,
            Order = 20)]
        [AllowedTypes(new[] { typeof(EventsContainerPageType) })]
        public virtual PageReference EventsPageContainerReference { get; set; }
    }
}