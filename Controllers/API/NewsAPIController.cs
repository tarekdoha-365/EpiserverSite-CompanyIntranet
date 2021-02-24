using EpiserverSite_CompanyIntranet.Entity;
using EpiserverSite_CompanyIntranet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace EpiserverSite_CompanyIntranet.Controllers.API
{
    [RoutePrefix("api/News")]

    public class NewsAPIController : ApiController
    {
        private readonly INewsService _newsService;
        public NewsAPIController(INewsService newsService)
        {
            _newsService = newsService;
        }
        [Route("Get/{language}/{pageId}")]
        [HttpGet]
        public News Get(Guid pageId, string language)
        {
            return _newsService.Get(pageId, language);
        }
        [Route("GetAll/{language}/{offset}/{limit}")]
        [HttpGet]
        public List<News> GetAll(int offset, int limit, string language)
        {
            return _newsService.GetAll(offset, limit, language);
        }
    }
}