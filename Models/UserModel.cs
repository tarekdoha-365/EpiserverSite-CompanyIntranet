using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite_CompanyIntranet.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public UserModel(string name, string password)
        {
            Password = password;
            Name = name;
        }
    }
}