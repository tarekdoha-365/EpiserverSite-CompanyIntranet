﻿using EpiserverSite_CompanyIntranet.Attributes;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;
using EpiserverSite_CompanyIntranet.Enums;

namespace EpiserverSite_CompanyIntranet.Models.Pages
{
    [ContentIcon(ContentIcon.List, ContentIconColor.Danger)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ContainerPageType) })]
    [ContentType(DisplayName = "EventsContainerPageType", GUID = "8ce0d9e1-1284-4f23-8381-b28b1cf46663", Description = "")]
    public class EventsContainerPageType : PageData
    {
        
    }
}