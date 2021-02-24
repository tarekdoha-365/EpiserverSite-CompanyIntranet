using EPiServer;
using EPiServer.Find;
using EpiserverSite_CompanyIntranet.Entity;
using EpiserverSite_CompanyIntranet.Interfaces;
using EpiserverSite_CompanyIntranet.Models.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EPiServer.Find.Cms;
using System.Web;

namespace EpiserverSite_CompanyIntranet.Services
{
    public class EventsService : IEventsService
    {
        private readonly IContentRepository _contentRepository;
        private readonly IClient _client;
        public EventsService(IContentRepository contentRepository, IClient client)
        {
            _contentRepository = contentRepository;
            _client = client;
        }
        public Event Get(Guid pageId, string language)
        {
            var eventPage = _contentRepository.Get<EventPageType>(pageId, new CultureInfo(language));
            return eventPage.GetSerializableNews();

        }
        public List<Event> GetAll(int offset, int limit, string language)
        {
            var eventPageList = _client.Search<EventPageType>()
                .FilterForVisitor(language)
                .OrderByDescending(x => x.Saved)
                .Take(limit).Skip(offset)
                .GetContentResult()
                .Items?.ToList();

            return eventPageList.Select(eventPage => eventPage.GetSerializableNews())?.ToList();
        }
    }
}