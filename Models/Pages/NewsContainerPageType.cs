using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EpiserverSite_CompanyIntranet.Attributes;
using EpiserverSite_CompanyIntranet.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Models.Pages
{
    [ContentIcon(ContentIcon.List, ContentIconColor.Default)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ContainerPageType) })]
    [ContentType(DisplayName = "NewsContainerPageType", GUID = "fd4628bc-7fb5-4280-ba4a-fe0b49720e4e", Description = "")]
    public class NewsContainerPageType : PageData
    {
       
    }
}