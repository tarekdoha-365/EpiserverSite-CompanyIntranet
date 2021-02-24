using EpiserverSite_CompanyIntranet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using EPiServer.Data;
using EPiServer;
using System.Web.Mvc;
using RouteAttribute = System.Web.Http.RouteAttribute;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using EpiserverSite_CompanyIntranet.Entity;

namespace EpiserverSite_CompanyIntranet.Controllers.API
{
    public class EventsAPIController : ApiController
    {
        private readonly IEventsService _eventsService;
        public EventsAPIController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }
        [Route("Get/{language}/{pageId}")]
        [HttpGet]
        public Event Get(Guid pageId, string language)
        {
            return _eventsService.Get(pageId, language);
        }

        [Route("GetAll/{language}/{offset}/{limit}")]
        [HttpGet]
        public List<Event> GetAll(int offset, int limit, string language)
        {
            return _eventsService.GetAll(offset, limit, language);
        }
    }
}