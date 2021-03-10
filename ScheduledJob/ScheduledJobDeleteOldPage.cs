using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EpiserverSite_CompanyIntranet.Interfaces;
using System;

namespace EpiserverSite_CompanyIntranet.ScheduledJob
{
    [ScheduledPlugIn(DisplayName = "ScheduledJobDeleteOldPage")]
    public class ScheduledJobDeleteOldPage : ScheduledJobBase
    {
        private bool _stopSignaled;
        private readonly INewsService _newsService;

        public ScheduledJobDeleteOldPage(INewsService newsService)
        {
            IsStoppable = true;
            _newsService = newsService;
        }

        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
        }

        /// <summary>
        /// Called when a scheduled job executes
        /// </summary>
        /// <returns>A status message to be stored in the database log and visible from admin mode</returns>
        public override string Execute()
        {
            //Call OnStatusChanged to periodically notify progress of job for manually started jobs
            OnStatusChanged(String.Format("Starting execution of {0}", this.GetType()));
            _newsService.Delete();

            //Add implementation

            //For long running jobs periodically check if stop is signaled and if so stop execution
            if (_stopSignaled)
            {
                return "Stop of job was called";
            }
            //throw new Exception("<font color=red>Error Tarek</font>");
            return "Change to message that describes outcome of execution";
        }
    }
}
