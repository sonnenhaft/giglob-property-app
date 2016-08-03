using System.Web.Http.Controllers;
using System.Web.Http.ExceptionHandling;
using Client.Api.Elmah;

namespace Client.Api
{
    public class ElmahConfiguration
    {
        public static void Configure(ServicesContainer services)
        {
            services.Add(typeof (IExceptionLogger), new ElmahExceptionLogger());
        }
    }
}