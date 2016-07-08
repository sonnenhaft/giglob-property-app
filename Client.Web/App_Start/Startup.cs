using System.Web.Routing;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Client.Web.Startup))]

namespace Client.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            RouteConfig.Configure(RouteTable.Routes);
        }
    }
}
