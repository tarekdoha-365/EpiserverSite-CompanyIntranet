using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EpiserverSite_CompanyIntranet.Business;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Models.Pages
{
    [ContentType(DisplayName = "ArticlePageType", GUID = "d056106c-04c1-42de-a2db-6d311d76ceee", Description = "")]
    public class ArticlePageType : SitePageData
    {
        [CultureSpecific]
        [Display(
                   Name = "Main body",
                   Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                   GroupName = SiteTabNames.Metadata,
                   Order = 550)]
        public virtual XhtmlString MainBody { get; set; }
    }
}