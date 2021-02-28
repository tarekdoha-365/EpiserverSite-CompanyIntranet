using EpiserverSite_CompanyIntranet.Attributes;
using EpiserverSite_CompanyIntranet.Enums;
using EPiServer.Cms.Shell;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace EpiserverSite_CompanyIntranet.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(InitializableModule))]
    public class Initializer: IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var registry = context.Locate.Advanced.GetInstance<UIDescriptorRegistry>();
            var classes = GetDescriptorClasses();

            foreach (var descriptor in registry.UIDescriptors)
            {
                if (classes.ContainsKey(descriptor.ForType))
                {
                    descriptor.IconClass += " " + classes[descriptor.ForType];
                }
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        private Dictionary<Type, string> GetDescriptorClasses()
        {
            var typesWithAttribute = GetTypesWithAttribute();

            var descriptors = new Dictionary<Type, string>();

            foreach (var type in typesWithAttribute)
            {
                var iconAttribute = (ContentIconAttribute)Attribute.GetCustomAttribute(type, typeof(ContentIconAttribute));

                var iconClass = $"epi-icon{iconAttribute.Icon.ToString()}";

                if (iconAttribute.Color != ContentIconColor.Default)
                {
                    iconClass += $" epi-icon--{iconAttribute.Color.ToString().ToLower()}";
                }

                descriptors.Add(type, iconClass);
            }

            return descriptors;
        }

        private List<Type> GetTypesWithAttribute()
        {
            var validAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.IsDynamic);
            var typesWithAttribute = new List<Type>();

            foreach (var assembly in validAssemblies)
            {

                typesWithAttribute.AddRange(assembly.GetTypes().Where(type => type.IsDefined(typeof(ContentIconAttribute), false)));
            }

            return typesWithAttribute;
        }
    }
}