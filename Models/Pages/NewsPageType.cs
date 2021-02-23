using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;
using EpiserverSite_CompanyIntranet.Enums;
using EPiServer.Web;
using EpiserverSite_CompanyIntranet.Attributes;
using EpiserverSite_CompanyIntranet.Models.Blocks;

namespace EpiserverSite_CompanyIntranet.Models.Pages
{
    [ContentIcon(ContentIcon.Page, ContentIconColor.Active)]
    [AvailableContentTypes(Availability.None)]
    [ContentType(DisplayName = "NewsPageType", GUID = "165b0b6d-b1f5-4eb4-9003-950b73e02f52", Description = "")]
    public class NewsPageType : PageData
    {
        [Display(
            Name = "Filter Tags",
            Description = "Select tags to make this article filterd by it",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual CategoryListBlockType FilterTags { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Article Title",
            Description = "Article Title",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string ArticleTitle { get; set; }

        [Display(
            Name = "Article Image",
            Description = "Select an image to be the main article image",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference ArticleImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Article Summary",
            Description = "Article Summary",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        [UIHint(UIHint.Textarea)]
        public virtual string ArticleSummary { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Full Article",
            Description = "Full Article",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual XhtmlString FullArticle { get; set; }
    }
}