﻿using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using EpiserverSite_CompanyIntranet.Models.Blocks.Base;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Models.Blocks
{
    [ContentType(DisplayName = "FeedsBlockType", GUID = "92b5c0a9-3e8e-4e86-9ce2-6e64d6343614", Description = "")]
    [ImageUrl("~/Content/Icon/jumbotronblocktype.jpg")]
    public class TeaserBlockType : SiteBlockData
    {
        [Display(Name = "Teaser Image", GroupName = SystemTabNames.Content, Order = 10)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference TeaserImage { get; set; }

        [Display(Name = "Teaser Text", GroupName = SystemTabNames.Content, Order = 20)]
        [CultureSpecific]
        public virtual string TeaserText { get; set; }

        [Display(Name = "Teaser Body", GroupName = SystemTabNames.Content, Order = 30)]
        [CultureSpecific]
        public virtual XhtmlString TeaserBody { get; set; }
        [Display(
            Name = "Header",
            Description = "Enter a header for the block",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [Required]
        public virtual string Header { get; set; }

        [Display(
            Name = "Description",
            Description = "Enter a Description for the block",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        [Required]
        public virtual XhtmlString Description { get; set; }
        [UIHint("Image")]
        [Display(
            Name = "Image",
            Description = "Chose a image for the block",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        [Required]
        public virtual Url Image { get; set; }

        [Display(
            Name = "Button label",
            Description = "Enter a label for the button",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        [Required]
        public virtual string Button { get; set; }

        [Display(
            Name = "Url",
            Description = "Enter a Url for the button",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        [Required]
        public virtual Url Url { get; set; }
    }
}