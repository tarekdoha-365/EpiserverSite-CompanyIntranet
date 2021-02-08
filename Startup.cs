using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EpiserverSite_CompanyIntranet.StartupOwin))]

namespace EpiserverSite_CompanyIntranet
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
