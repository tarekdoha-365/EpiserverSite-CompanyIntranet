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
    [ContentIcon(ContentIcon.Folder, ContentIconColor.Warning)]
    [ContentType(DisplayName = "ContainerPageType", GUID = "8631e63a-eee5-4174-9a9e-e107b34456c0", Description = "")]
    public class ContainerPageType : PageData
    {
       
    }
}