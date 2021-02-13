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
        [CultureSpecific]
        [Display(
                    Name = "Page Title",
                    Description = "This is a Page Title",
                    GroupName = "Config",
                    Order = 100)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Main Body",
           Description = "This is a Main Body",
           GroupName = "Config",
           Order = 200)]
        //[PropertyEditRestriction(new string[] { "administrators2" })]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Link List",
           Description = "This is a Link List",
           GroupName = "Config",
           Order = 300)]
        public virtual LinkItemCollection LinkList { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Content Area",
           Description = "This is a Content Area",
           GroupName = "Config",
           Order = 400)]
        public virtual ContentArea ContentArea { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Boolean Property",
           Description = "This is a Boolean Property",
           GroupName = "Config",
           Order = 500)]
        public virtual bool BooleanProperty { get; set; }
        [CultureSpecific]
        [Display(
           Name = "Content Reference",
           Description = "This is a Content Reference",
           GroupName = "Config",
           Order = 600)]
        public virtual ContentReference ContentReference { get; set; }

        [CultureSpecific]
        [Display(
           Name = "Page Reference",
           Description = "This is a Page Reference",
           GroupName = "Config",
           Order = 700)]
        public virtual PageReference PageReference { get; set; }

        [Display(
            Name = "Search Page",
            Description = "",
            GroupName = SiteTabNames.SiteOptions,
            Order = 1000)]
        public virtual PageReference SearchPage { get; set; }
    }
}