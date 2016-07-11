using System.Web.Http;
using ApiVersioningModule.Extensions;

namespace Client.Api
{
    public class RouteConfiguration
    {
        public static void Configure(HttpRouteCollection routes)
        {
            routes.MapUrlVersionedHttpRoute("Default", "{controller}/{action}/{id}", new { id = RouteParameter.Optional });
        }
    }
}