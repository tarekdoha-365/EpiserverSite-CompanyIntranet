using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Infrastructure.Models.Media
{
    [ContentType(DisplayName = "ImageFile", GUID = "3d40db36-a3c9-49dd-8ab3-4c9b182db365", Description = "")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png,svg")]
    public class ImageFile : ImageData
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
        Name = "Description",
        Description = "Description field's description",
        GroupName = SystemTabNames.Content,
        Order = 10)]
        public virtual string Description { get; set; }
    }
}