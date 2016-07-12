using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using ApiVersioningModule.HttpControllerSelectors;
using ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.VersionNumberResolvers.Interfaces;

namespace ApiVersioningModule
{
    public class ApiVersioningConfiguration
    {
        public static void Configure(HttpConfiguration config, IApiVersionResolver apiVersionResolver, INoApiVersionResolver noApiVersionResolver)
        {
            config.Services.Replace(typeof(IHttpControllerSelector), new ApiVersionControllerSelector(config, apiVersionResolver, noApiVersionResolver));
        }
    }
}