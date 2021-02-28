using EpiserverSite_CompanyIntranet.Attributes;
using EpiserverSite_CompanyIntranet.Constants;
using EpiserverSite_CompanyIntranet.Entity;
using EpiserverSite_CompanyIntranet.Models.Blocks;
using EpiserverSite_CompanyIntranet.Models.Pages.Base;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;
using EpiserverSite_CompanyIntranet.Enums;


namespace EpiserverSite_CompanyIntranet.Models.Pages
{
    [ContentIcon(ContentIcon.Page, ContentIconColor.Danger)]
    [ContentType(DisplayName = "EventPageType", GUID = "0ca9267f-d8f3-4345-aa4c-92626cc22385", Description = "")]
    public class EventPageType : SearchablePageType
    {
        [Display(
            Name = "Filter Tags",
            Description = "Select tags to make this article filterd by it",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual CategoryListBlockType FilterTags { get; set; }

        [Display(
            Name = "Country Tags",
            Description = "Select countries to make this article visible for the employees from selected countries",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [CategorySelection(RootCategoryName = SiteConstants.Events)]
        [UIHint(SiteUIHint.CustomCategories)]
        public virtual CategoryList Events { get; set; }

        [Display(
            Name = "Event Start",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual DateTime EventStart { get; set; }

        [Display(
            Name = "Event End",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual DateTime EventEnd { get; set; }

        [Display(
            Name = "Address",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual string Address { get; set; }

        [Display(
            Name = "Meeting Link",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 60)]
        public virtual string MeetingLink { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Display Name",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 70)]
        public virtual string DisplayName { get; set; }

        [CultureSpecific]
        [Display(
            Name = "About This Event",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 80)]
        public virtual XhtmlString AboutThisEvent { get; set; }
        internal Event GetSerializableNews()
        {
            return new Event()
            {

                Guid = ContentGuid,
                Created = Created.ToString("yyyy-MM-ddTHH:mm:ss"),
                Modified = Saved.ToString("yyyy-MM-ddTHH:mm:ss"),
                CreatedBy = CreatedBy,
                ModifiedBy = ChangedBy,
                DisplayName = DisplayName,
                EventStart = EventStart.ToString("yyyy-MM-ddTHH:mm:ss"),
                EventEnd = EventEnd.ToString("yyyy-MM-ddTHH:mm:ss"),
                Address = Address,
                MeetingLink = MeetingLink,
                AboutThisEvent = AboutThisEvent?.ToHtmlString()
            };
        }
    }
}