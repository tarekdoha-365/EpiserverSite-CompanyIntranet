using EpiserverSite_CompanyIntranet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiserverSite_CompanyIntranet.Interfaces
{
    public interface INewsService
    {
        News Get(Guid pageId, string language);
        List<News> GetAll(int offset, int limit, string language);
    }
}
