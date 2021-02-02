using EPiServer.Validation;
using EpiserverSite_CompanyIntranet.Models.Pages;
using System.Collections.Generic;
using EPiServer.Core;
using EpiserverSite_CompanyIntranet.Infrastructure.Interfaces;

namespace EpiserverSite_CompanyIntranet.Infrastructure.Services
{
    public class SiteValidationService : ISiteValidationService
    {
        public IEnumerable<ValidationError> ValidateStartPage(StartPageType instance)
        {
            throw new System.NotImplementedException();
        }
    }
}