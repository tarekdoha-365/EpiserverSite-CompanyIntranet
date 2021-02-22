using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EpiserverSite_CompanyIntranet.Business;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Models.Pages
{
    [ContentType(DisplayName = "BlogPageType", GUID = "8917b769-d3d2-43c9-b82b-b459a6abc539", Description = "")]
    public class BlogPageType : SitePageData
    {
        [CultureSpecific]
        [Display(
                   Name = "Main body",
                   Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                   GroupName = SiteTabNames.Metadata,
                   Order = 580)]
        public virtual XhtmlString MainBody { get; set; }
    }
}