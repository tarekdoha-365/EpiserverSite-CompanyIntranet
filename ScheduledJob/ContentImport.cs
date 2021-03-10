using EPiServer;
using EPiServer.BaseLibrary.Scheduling;
using EPiServer.Logging.Compatibility;
using EPiServer.PlugIn;
using EpiserverSite_CompanyIntranet.Interfaces;
using EpiserverSite_CompanyIntranet.Models.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;

namespace EpiserverSite_CompanyIntranet.ScheduledJob
{
    [ScheduledPlugIn(DisplayName = "Bulk Content Import",
    SortIndex = 100)]
    public class ContentImport : JobBase
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IContentRepository _contentRepository;
        private int contentProcessed;
        private int contentNotProcessed;
        private readonly INewsService _newsService;
        public ContentImport(IContentRepository contentRepository, INewsService newsService)
        {
            _newsService = newsService;
            _contentRepository = contentRepository;
            IsStoppable = true;
            contentProcessed = 0;
            contentNotProcessed = 0;
        }

        private long Duration { get; set; }
        private DateTime DateTime { get; set; }

        public override string Execute()
        {
            var tmr = Stopwatch.StartNew();

            try
            {   //From IContentRepository
                //void Delete(ContentReference contentLink, bool forceDelete, AccessLevel access);
                _newsService.Delete();
            }
            catch (Exception ex)
            {
                contentNotProcessed = contentNotProcessed++;
                Logger.Error(ex);
            }

            tmr.Stop();
            Duration = tmr.ElapsedMilliseconds;

            return ToString();
        }

        public override string ToString()
        {
            var logMesssage = contentNotProcessed > 0 ? "Please check the logs for the failed products." : string.Empty;

            return string.Format(
                "Processed {0} in {1}ms on {2}. {3}",
                contentProcessed,
                Duration,
                Environment.MachineName,
                logMesssage);
        }
    }
}