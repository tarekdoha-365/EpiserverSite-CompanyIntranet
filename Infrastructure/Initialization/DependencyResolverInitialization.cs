using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EpiserverSite_CompanyIntranet.Business;
using StructureMap;
using System.Web.Http;
using System.Web.Mvc;

namespace EpiserverSite_CompanyIntranet.Infrastructure.Initialization
{
    public class DependencyResolverInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.StructureMap().Configure(ConfigureContainer);
            var resolver = new StructureMapDependencyResolver(context.StructureMap());
            DependencyResolver.SetResolver(resolver);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        private static void ConfigureContainer(ConfigurationExpression container)
        {
            container.Scan(x =>
            {
                x.Assembly("EpiserverSite-Demo");
                x.WithDefaultConventions();
                x.LookForRegistries();
            });
        }
        public void Initialize(InitializationEngine context)
        {

        }
        public void Uninitialize(InitializationEngine context)
        {
        }
        public void Preload(string[] parameters)
        {
        }
    }
}