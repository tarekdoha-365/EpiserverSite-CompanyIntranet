using EPiServer.DataAnnotations;
using EPiServer.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpiserverSite_CompanyIntranet.Business
{
    public static class SiteTabNames
    {
        [Display(Order = 100)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string Metadata = "Metadata";

        [Display(Order = 110)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string YourCustomTabName1 = "Your Custom Tab Name 1";

        [Display(Order = 120)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string YourCustomTabName2 = "Your Custom Tab Name 2";

        [Display(Order = 130)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string YourCustomTabName3 = "Your Custom Tab Name 3";
    }
}