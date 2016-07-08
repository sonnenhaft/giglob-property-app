using System.Web.Mvc;
using System.Web.Routing;

namespace Client.Web
{
    public class RouteConfig
    {
        public static void Configure(RouteCollection routes)
        {
            routes.LowercaseUrls = true;
            routes.MapRoute("Default", "{*.}", new { controller = "Home", action = "Index" });
        }
    }
}