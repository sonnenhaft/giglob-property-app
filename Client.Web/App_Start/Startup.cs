using System.Web.Routing;
using Client.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

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