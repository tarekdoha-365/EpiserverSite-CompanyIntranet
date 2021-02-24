using  EpiserverSite_CompanyIntranet.Interfaces;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Logging;
using EPiServer.ServiceLocation;
using EpiserverSite_CompanyIntranet.Models.Pages;
using EPiServer.DataAccess;
using EPiServer.Security;
using System.Linq;

namespace EpiserverSite_CompanyIntranet.Initialization
{
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class ContentEventsModule : IInitializableModule
    {
        private static ILogger _logger = LogManager.GetLogger(typeof(ContentEventsModule));
        private ICacheManager _cacheManager;
        private IContentEvents _contentEvents;
        private IContentRepository _contentRepository;
        public void Initialize(InitializationEngine context)
        {
            _cacheManager = ServiceLocator.Current.GetInstance<ICacheManager>();
            _contentEvents = ServiceLocator.Current.GetInstance<IContentEvents>();
            _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            _contentEvents.PublishedContent += Instance_ContentChangedUpdateCache;
            _contentEvents.MovedContent += Instance_ContentChangedUpdateCache;
            _contentEvents.DeletedContent += Instance_ContentChangedUpdateCache;
            _contentEvents.SavedContent += Instance_ContentChangedUpdateCache;
            _contentEvents.MovingContent += Instance_ContentChangedUpdateCache;
            _contentEvents.MovingContent += MovingContent;
            _contentEvents.PublishingContent += Instance_ContentPublishing;
            _contentEvents.PublishedContent += Instance_ContentPublished;
            _contentEvents.CreatedContent += Instance_CreateYearMonthContainersForNewsPages;
        }
        public void Uninitialize(InitializationEngine context)
        {
            _contentEvents.PublishedContent -= Instance_ContentChangedUpdateCache;
            _contentEvents.MovedContent -= Instance_ContentChangedUpdateCache;
            _contentEvents.DeletedContent -= Instance_ContentChangedUpdateCache;
            _contentEvents.SavedContent -= Instance_ContentChangedUpdateCache;
            _contentEvents.MovingContent -= Instance_ContentChangedUpdateCache;
            _contentEvents.MovingContent -= MovingContent;
            _contentEvents.PublishingContent -= Instance_ContentPublishing;
            _contentEvents.PublishedContent -= Instance_ContentPublished;
            _contentEvents.CreatedContent -= Instance_CreateYearMonthContainersForNewsPages;
        }
        void Instance_ContentChangedUpdateCache(object sender, ContentEventArgs e)
        {
            _cacheManager.OnContentChange(sender, e);
        }
        void Instance_ContentPublished(object sender, ContentEventArgs e)
        {
        }
        void Instance_ContentPublishing(object sender, ContentEventArgs e)
        {
        }
        private void MovingContent(object sender, ContentEventArgs e)
        {
            if (e.Content is StartPageType ||
                e.Content is SearchPageType ||
                e.Content is NewsContainerPageType ||
                e.Content is AboutUsPageType ||
                e.Content is ContactPageType ||
                e.Content is GlobalSettingsPageType)
            {
                e.CancelAction = true;
                e.CancelReason = "Not Allowed To Delete PageType";
            }
        }
        void Instance_CreateYearMonthContainersForNewsPages(object sender, ContentEventArgs e)
        {
            var newsPage = e.Content as NewsPageType;
            if (newsPage != null)
            {
                var newsPageCreated = newsPage.Created;
                var startPage = _contentRepository.Get<StartPageType>(ContentReference.StartPage);
                if (startPage.GlobalSettingsPageReference == null)
                {
                    throw new EPiServerCancelException("Global Settings Page not set in Start page");
                }
                var globalSettingsPage = _contentRepository.Get<GlobalSettingsPageType>(startPage.GlobalSettingsPageReference);
                var newsContainerPage = globalSettingsPage.NewsPageContainerReference;
                if (newsContainerPage == null)
                {
                    throw new EPiServerCancelException("News Container Page not set in Global Settings Page");
                }
                var yearPage = CreateYearContainer(newsPageCreated.Year.ToString(), newsContainerPage);
                var monthPage = CreateMonthContainer(newsPageCreated.ToString("MM"), yearPage);
                if (newsPage.ParentLink != monthPage)
                {
                    _contentRepository.Move(newsPage.ContentLink.ToPageReference(), monthPage, AccessLevel.NoAccess, AccessLevel.NoAccess);
                }
            }
        }
        PageReference CreateYearContainer(string pageName, PageReference parent)
        {
            var existingContainerPage = GetContainerPageByName(pageName, parent);
            if (existingContainerPage == null)
            {
                var parentContentReference = _contentRepository.Get<NewsContainerPageType>(parent);
                var containerPage = _contentRepository.GetDefault<ContainerPageType>(parentContentReference.ContentLink);
                containerPage.Name = pageName;
                _contentRepository.Save(containerPage, SaveAction.Publish, AccessLevel.NoAccess);
                _logger.Information($"Creating year container for year: {pageName}");
                return containerPage.ContentLink.ToPageReference();
            }
            return existingContainerPage.ContentLink.ToPageReference();
        }
        PageReference CreateMonthContainer(string pageName, PageReference parent)
        {
            var existingContainerPage = GetContainerPageByName(pageName, parent);
            if (existingContainerPage == null)
            {
                var parentContentReference = _contentRepository.Get<ContainerPageType>(parent);
                var containerPage = _contentRepository.GetDefault<ContainerPageType>(parentContentReference.ContentLink);
                containerPage.Name = pageName;
                _contentRepository.Save(containerPage, SaveAction.Publish, AccessLevel.NoAccess);
                _logger.Information($"Creating year container for month: {pageName}");
                return containerPage.ContentLink.ToPageReference();
            }
            return existingContainerPage.ContentLink.ToPageReference();
        }
        ContainerPageType GetContainerPageByName(string containerPageName, PageReference parent)
        {
            return _contentRepository.GetChildren<ContainerPageType>(parent).FirstOrDefault(x => x.PageName == containerPageName);
        }
    }
}