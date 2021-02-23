using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EpiserverSite_CompanyIntranet.Attributes;
using EpiserverSite_CompanyIntranet.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite_CompanyIntranet.Models.Blocks
{
    [ContentType(DisplayName = "CategoryListBlockType", GUID = "ad92e4d2-0ec7-4214-8435-edccf82612bc", Description = "")]
    public class CategoryListBlockType : BlockData
    {
        [Display(
            Name = "Country Tags",
            Description = "Select countries to make this article visible for the employees from selected countries",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [CategorySelection(RootCategoryName = SiteConstants.Countries)]
        [UIHint(SiteUIHint.CustomCategories)]
        public virtual CategoryList Countries { get; set; }

        [Display(
            Name = "Department Tags",
            Description = "Select Departments to make this article visible for the employees from selected Departments",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [CategorySelection(RootCategoryName = SiteConstants.Departments)]
        [UIHint(SiteUIHint.CustomCategories)]
        public virtual CategoryList Departments { get; set; }

        [Display(
            Name = "Employee Level Tags",
            Description = "Select Employee Levels to make this article visible for the employees from selected Employee Levels",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        [CategorySelection(RootCategoryName = SiteConstants.EmployeeLevels)]
        [UIHint(SiteUIHint.CustomCategories)]
        public virtual CategoryList EmployeeLevels { get; set; }
    }
}