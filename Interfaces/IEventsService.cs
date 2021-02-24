using EpiserverSite_CompanyIntranet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiserverSite_CompanyIntranet.Interfaces
{
    public interface IEventsService
    {
        Event Get(Guid pageId, string language);
        List<Event> GetAll(int offset, int limit, string language);
    }
}
