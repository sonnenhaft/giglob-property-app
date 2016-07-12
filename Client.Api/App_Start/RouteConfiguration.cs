using System.Web.Http;
using System.Web.Routing;
using ApiVersioningModule.Extensions;

namespace Client.Api
{
    public class RouteConfiguration
    {
        public static void Configure(HttpRouteCollection routes)
        {
            RouteTable.Routes.Ignore("{resource}.axd/{*pathInfo}");
            routes.MapUrlVersionedHttpRoute("Default", "{controller}/{action}/{id}", new { id = RouteParameter.Optional });
        }
    }
}