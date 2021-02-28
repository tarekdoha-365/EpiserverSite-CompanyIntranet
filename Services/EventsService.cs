using EPiServer;
using EPiServer.Find;
using EpiserverSite_CompanyIntranet.Entity;
using EpiserverSite_CompanyIntranet.Interfaces;
using EpiserverSite_CompanyIntranet.Models.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EPiServer.Find.Cms;
using System.Web;
using EPiServer.Validation;

namespace EpiserverSite_CompanyIntranet.Services
{
    public class StartPageValidator : IValidate<StartPageType>
    {
        public readonly ISiteValidationService _siteValidationService;
        public StartPageValidator(ISiteValidationService siteValidationService)
        {
            _siteValidationService = siteValidationService;
        }
        public IEnumerable<ValidationError> Validate(StartPageType instance)
        {
            return _siteValidationService.ValidateStartPage(instance);
        }
    }
}