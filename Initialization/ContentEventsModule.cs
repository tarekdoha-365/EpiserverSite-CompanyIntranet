using  EpiserverSite_CompanyIntranet.Interfaces;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Logging;
using EPiServer.ServiceLocation;

namespace EpiserverSite_CompanyIntranet.Initialization
{
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class ContentEventsModule : IInitializableModule
    {
        private static ILogger _logger = EPiServer.Logging.LogManager.GetLogger(typeof(ContentEventsModule));
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
            _contentEvents.PublishingContent += Instance_ContentPublishing;
            _contentEvents.PublishedContent += Instance_ContentPublished;
        }
        public void Uninitialize(InitializationEngine context)
        {
            _contentEvents.PublishedContent -= Instance_ContentChangedUpdateCache;
            _contentEvents.MovedContent -= Instance_ContentChangedUpdateCache;
            _contentEvents.DeletedContent -= Instance_ContentChangedUpdateCache;
            _contentEvents.SavedContent -= Instance_ContentChangedUpdateCache;
            _contentEvents.MovingContent -= Instance_ContentChangedUpdateCache;
            _contentEvents.PublishingContent -= Instance_ContentPublishing;
            _contentEvents.PublishedContent -= Instance_ContentPublished;
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
    }
}