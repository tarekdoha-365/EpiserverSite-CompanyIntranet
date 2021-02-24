using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using EpiserverSite_CompanyIntranet.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EpiserverSite_CompanyIntranet.EditorDescriptors
{
    public class CustomCategoryListEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(
           ExtendedMetadata metadata,
           IEnumerable<Attribute> attributes)
        {

            base.ModifyMetadata(metadata, attributes);
            var categorySelectionAttribute =
                attributes.OfType<CategorySelectionAttribute>().FirstOrDefault();

            if (categorySelectionAttribute != null)
            {
                metadata.EditorConfiguration["root"] =
                    categorySelectionAttribute.GetRootCategoryId();
                return;
            }

            var contentTypeCategorySelectionAttribute =
                metadata.ContainerType.GetCustomAttributes(true).FirstOrDefault() as CategorySelectionAttribute;

            if (contentTypeCategorySelectionAttribute != null)
            {
                metadata.EditorConfiguration["root"] =
                    contentTypeCategorySelectionAttribute.GetRootCategoryId();
            }
        }
    }
}