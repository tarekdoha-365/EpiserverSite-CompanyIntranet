using EpiserverSite_CompanyIntranet.Business;
using EpiserverSite_CompanyIntranet.Models.Pages.Base;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Models.Pages
{
    [ContentType(DisplayName = "StartPageType", GUID = "1bb6d290-ad32-4e27-9905-e270b5a74543", Description = "")]
    public class StartPageType : SitePageData
    {
        [Display(
                    Name = "Global Settings Page Reference",
                    Description = "Reference to the Global Settings Page",
                    GroupName = SiteTabNames.SiteOptions,
                    Order = 10)]
        [AllowedTypes(new[] { typeof(GlobalSettingsPageType) })]
        public virtual PageReference GlobalSettingsPageReference { get; set; }

    }
}