using EpiserverSite_CompanyIntranet.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Web.Routing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using EpiserverSite_CompanyIntranet.Interfaces;
using EpiserverSite_CompanyIntranet.Entity;

namespace EpiserverSite_CompanyIntranet.Services
{
    public class NewsService : INewsService
    {
        private readonly IContentRepository _contentRepository;
        private readonly IClient _client;
        public NewsService(IContentRepository contentRepository, IClient client)
        {
            _contentRepository = contentRepository;
            _client = client;
        }
        public News Get(Guid pageId, string language)
        {
            var newsPage = _contentRepository.Get<NewsPageType>(pageId, new CultureInfo(language));
            return newsPage.GetSerializableNews();

        }
        public List<News> GetAll(int offset, int limit, string language)
        {
            var NewsPageList = _client.Search<NewsPageType>()
                .FilterForVisitor(language)
                .OrderByDescending(x => x.Saved)
                .Take(limit).Skip(offset)
                .GetContentResult()
                .Items?.ToList();

            return NewsPageList.Select(newsPage => newsPage.GetSerializableNews())?.ToList();
        }
    }
}