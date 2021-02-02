using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Infrastructure.Models.Media
{
    [ContentType(DisplayName = "VideoFile", GUID = "b93891e6-66bb-46ba-ae83-59f28d0c3429", Description = "")]
    /*[MediaDescriptor(ExtensionString = "flv,mp4,webm")]*/
    public class VideoFile : MediaData
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
        Name = "Description",
        Description = "Description field's description",
        GroupName = SystemTabNames.Content,
        Order = 10)]
        public virtual string Description { get; set; }
        /// <summary> 
        /// Gets or sets the copyright. 
        /// </summary> 
        public virtual string Copyright { get; set; }
        /// <summary> 
        /// Gets or sets the URL to the preview image. 
        /// </summary> 
        [UIHint(UIHint.Image)]
        public virtual ContentReference PreviewImage { get; set; }
    }
}