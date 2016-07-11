using System.Net.Http;
using ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.VersionNumberResolvers.Interfaces;

namespace ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.VersionNumberResolvers
{
    public class UrlApiVersionResolver : IApiVersionResolver
    {
        public int? Resolve(HttpRequestMessage request)
        {
            object versionObj;
            var success = request.GetRouteData()
                                 .Values.TryGetValue("version", out versionObj);

            if(!success)
            {
                return null;
            }

            return int.Parse((string) versionObj);
        }
    }
}