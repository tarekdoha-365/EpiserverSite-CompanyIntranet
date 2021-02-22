using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Models.Blocks.Base
{
    [ContentType(DisplayName = "SiteBlockData", GUID = "e87c90d2-d431-4958-a35d-91b7f4f6529f", Description = "")]
    public class SiteBlockData : BlockData
    {
        [Display(Name = "Heading", Description = "Heading", GroupName = SystemTabNames.Content, Order = 10)]
        public virtual string Heading { get; set; }
    }
}