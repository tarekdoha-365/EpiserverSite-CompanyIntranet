using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite_CompanyIntranet.Attributes
{
    public class CategorySelectionAttribute:Attribute
    {
        /// 
        ///  ID of the root category.
        /// 
        public int RootCategoryId { get; set; }

        /// 
        /// Name of the root category.
        /// 
        public string RootCategoryName { get; set; }

        public int GetRootCategoryId()
        {
            if (RootCategoryId > 0)
            {
                return RootCategoryId;
            }
            var categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();
            if (!string.IsNullOrWhiteSpace(RootCategoryName))
            {
                var category = categoryRepository.Get(RootCategoryName);

                if (category != null)
                {
                    return category.ID;
                }
            }

            return categoryRepository.GetRoot().ID;
        }
    }
}