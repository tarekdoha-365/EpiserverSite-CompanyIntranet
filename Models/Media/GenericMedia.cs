using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Infrastructure.Models.Media
{
    [ContentType(DisplayName = "GenericMedia", GUID = "c999a7cd-21b8-4b7f-bf69-b4491e192926", Description = "")]
    [MediaDescriptor(ExtensionString = "pdf,doc,docx,ppt,pptx,xls,xlsx")]
    public class GenericMedia : MediaData
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