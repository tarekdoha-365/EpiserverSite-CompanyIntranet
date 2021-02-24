using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Find.UnifiedSearch;
using EPiServer.Find.Framework;
using EPiServer.Find;
using System.Linq.Expressions;
using EPiServer.Framework;
using EPiServer.Find.Cms;
using System;
using EPiServer.Find.Cms.Conventions;
using EPiServer.Core;
using EpiserverSite_CompanyIntranet.Interfaces;
using EpiserverSite_CompanyIntranet.Models.Pages.Base;
using EpiserverSite_CompanyIntranet.Models.Media;

namespace EpiserverSite_CompanyIntranet.Initialization
{
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class EpiserverFindInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            ContentIndexer.Instance.Conventions.ForInstancesOf<IContent>().ShouldIndex(x => false);
            ContentIndexer.Instance.Conventions.ForInstancesOf<ContentAssetFolder>().ShouldIndex(x => false);
            ContentIndexer.Instance.Conventions.ForInstancesOf<ContentFolder>().ShouldIndex(x => false);
            ContentIndexer.Instance.Conventions.ForInstancesOf<SearchablePageType>().ShouldIndex(x => true);
            ContentIndexer.Instance.Conventions.ForInstancesOf<SearchablePageType>().IndexingInContentAreas(x => true);
            ContentIndexer.Instance.Conventions.ForInstancesOf<SearchablePageType>().ReindexingRelatedContentWhenInContentArea(x => false);
            ContentIndexer.Instance.MediaBatchSize = 1;
            ContentIndexer.Instance.ContentBatchSize = 1;
            SearchClient.Instance.Conventions.UnifiedSearchRegistry.ForInstanceOf<GenericMedia>()
            .ProjectExcerptUsing<ISearchContent>(spec =>
            doc =>
            !string.IsNullOrWhiteSpace(doc.SearchAttachmentText)
            ? doc.SearchAttachmentText.AsCropped(50)
            : doc.SearchAttachment.AsCropped(50)
            )
            .ProjectHighlightedExcerptUsing(HighlightExpressionGetter);
        }

        private static Expression<Func<ISearchContent, string>> HighlightExpressionGetter(HitSpecification spec)
        {
            var highlightSpec = new HighlightSpec
            {
                FragmentSize = spec.ExcerptLength,
                NumberOfFragments = 1,
                PreTag = spec.PreTagForAllHighlights,
                PostTag = spec.PostTagForAllHighlights
            };

            return doc => !string.IsNullOrWhiteSpace(doc.SearchAttachmentText) ?
                    doc.SearchAttachmentText.AsHighlighted(highlightSpec) : doc.SearchAttachment.AsHighlighted(highlightSpec);
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}