using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite_CompanyIntranet.Entity
{
    public class Event
    {
        public Guid Guid { get; set; }
        public List<string> CountryTags { get; set; }
        public List<string> DepartmentTags { get; set; }
        public List<string> EmployeeLevelTags { get; set; }
        public List<string> EventsTag { get; set; }
        public string Created { get; set; }
        public string CreatedBy { get; set; }
        public string Modified { get; set; }
        public string ModifiedBy { get; set; }
        public string EventStart { get; set; }
        public string EventEnd { get; set; }
        public string DisplayName { get; set; }
        public string Address { get; set; }
        public string MeetingLink { get; set; }
        public string AboutThisEvent { get; set; }
    }
}