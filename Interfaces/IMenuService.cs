﻿using EpiserverSite_CompanyIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiserverSite_CompanyIntranet.Interfaces
{
    public interface IMenuService
    {
        List<MenuItem> GetTopMenu();
    }
}
