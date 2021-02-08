using EPiServer.Validation;
using EpiserverSite_CompanyIntranet.Models.Pages;
using System.Collections.Generic;
using EPiServer.Core;
using EpiserverSite_CompanyIntranet.Interfaces;

namespace EpiserverSite_CompanyIntranet.Services
{
    public class SiteValidationService : ISiteValidationService
    {
        public IEnumerable<ValidationError> ValidateStartPage(StartPageType instance)
        {
            var condition1 = false;
            var condition2 = false;
            var condition3 = false;
            var condition4 = false;
            if (condition1)
            {
                yield return new ValidationError()
                {
                    ErrorMessage = "Error message1",
                    PropertyName = instance.GetPropertyName(property => property.PageName),
                    Severity = ValidationErrorSeverity.Error, //None, Info, Worning, Error
                    ValidationType = ValidationErrorType.AttributeMatched //Unspecified, AttributeM
                };
            }
            if (condition2)
            {
                yield return new ValidationError()
                {
                    ErrorMessage = "Error message2",
                    PropertyName = instance.GetPropertyName(property => property.PageName),
                    Severity = ValidationErrorSeverity.Error, //None, Info, Worning, Error
                    ValidationType = ValidationErrorType.AttributeMatched //Unspecified, AttributeM
                };
            }
            if (condition3)
            {
                yield return new ValidationError()
                {
                    ErrorMessage = "Error message3",
                    PropertyName = instance.GetPropertyName(property => property.PageName),
                    Severity = ValidationErrorSeverity.Info, //None, Info, Worning, Error
                    ValidationType = ValidationErrorType.AttributeMatched //Unspecified, AttributeM
                };
            }
            if (condition4)
            {
                yield return new ValidationError()
                {
                    ErrorMessage = "Error message4",

                    PropertyName = instance.GetPropertyName(property => property.PageName),
                    Severity = ValidationErrorSeverity.Warning, //None, Info, Worning, Error
                    ValidationType = ValidationErrorType.AttributeMatched //Unspecified, AttributeM
                };
            }
        }
    }
}