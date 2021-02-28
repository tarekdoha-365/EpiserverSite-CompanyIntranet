using EpiserverSite_CompanyIntranet.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite_CompanyIntranet.Attributes
{
    public class ContentIconAttribute : Attribute
    {
        public ContentIcon Icon { get; set; }
        public ContentIconColor Color { get; set; }

        public ContentIconAttribute(ContentIcon icon, ContentIconColor color = ContentIconColor.Default)
        {
            Icon = icon;
            Color = color;
        }
    }
}