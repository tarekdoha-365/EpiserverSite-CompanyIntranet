using EpiserverSite_CompanyIntranet.Models.Pages;
using EPiServer.DataAbstraction;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Logging;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite_CompanyIntranet.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Data.DataInitialization))]
    public class RestrictRootPages : IInitializableModule
    {
        private IContentTypeRepository _contentTypeRepository;
        private IAvailableSettingsRepository _availableSettingsRepository;
        public void Initialize(InitializationEngine context)
        {
            _contentTypeRepository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();
            _availableSettingsRepository = ServiceLocator.Current.GetInstance<IAvailableSettingsRepository>();
            var sysRoot = _contentTypeRepository.Load("SysRoot") as PageType;
            var setting = new AvailableSetting
            {
                Availability = Availability.None,
                //Availability = Availability.Specific,
                /*AllowedContentTypeNames =
                {
                    nameof(StartPageType), // can't use custom interfaces with IContentTypeRepository
                }*/
            };
            _availableSettingsRepository.RegisterSetting(sysRoot, setting);
            // Disallow insertion for all product and article related pages
            DisallowAll<AboutUsPageType>();
            DisallowAll<ContactPageType>();
            //DisallowAll<NewsPageContainerType>();
            DisallowAll<SearchPageType>();
            DisallowAll<NewsPageType>();
            DisallowAll<StartPageType>();
            // Home Page
            SetPageRestriction<NewsContainerPageType>(new List<Type>
            {
                typeof(NewsPageType)
            });

        }

        public void Preload(string[] parameters)
        {

        }

        public void Uninitialize(EPiServer.Framework.Initialization.InitializationEngine context)
        {

        }

        private void DisallowAll<T>()
        {
            var page = _contentTypeRepository.Load(typeof(T));
            var setting = new AvailableSetting
            {
                Availability = Availability.None
            };
            _availableSettingsRepository.RegisterSetting(page, setting);
        }

        private void SetPageRestriction<T>(IEnumerable<Type> pageTypes)
        {
            var page = _contentTypeRepository.Load(typeof(T));
            var setting = new AvailableSetting
            {
                Availability = Availability.Specific
            };
            foreach (var pageType in pageTypes)
            {
                var contentType = _contentTypeRepository.Load(pageType);
                setting.AllowedContentTypeNames.Add(contentType.Name);
            }
            _availableSettingsRepository.RegisterSetting(page, setting);
        }
    }
}