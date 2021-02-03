using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Models.Blocks
{
    [ContentType(DisplayName = "FeedsBlockType", GUID = "92b5c0a9-3e8e-4e86-9ce2-6e64d6343614", Description = "")]
    public class FeedsBlockType : BlockData
    {
        [CultureSpecific]
        [Display(
                 Name = "Heading",
                 Description = "Add a heading.",
                 GroupName = SystemTabNames.Content,
                 Order = 1000)]
        public virtual String Heading { get; set; }


        [Display(
            Name = "Image", Description = "Add an image (optional)",
            GroupName = SystemTabNames.Content,
            Order = 1100)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image1 { get; set; }
        [Display(
            Name = "Video", Description = "Add an image (optional)",
            GroupName = SystemTabNames.Content,
            Order = 1100)]
        public virtual Url Video { get; set; }

    }
}