using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Validation;
using EpiserverSite_CompanyIntranet.Models.Pages;

namespace EpiserverSite_CompanyIntranet.Infrastructure.Interfaces
{
   public interface ISiteValidationService
    {
        IEnumerable<ValidationError> ValidateStartPage(StartPageType instance);
    }
}
