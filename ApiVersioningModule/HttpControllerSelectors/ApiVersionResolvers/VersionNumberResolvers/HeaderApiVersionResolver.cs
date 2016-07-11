using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.VersionNumberResolvers.Interfaces;

namespace ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.VersionNumberResolvers
{
    public class HeaderApiVersionResolver : IApiVersionResolver
    {
        public int? Resolve(HttpRequestMessage request)
        {
            IEnumerable<string> headerValues;
            var success = request.Headers.TryGetValues("ApiVersion", out headerValues);

            return success ? (int?) int.Parse(headerValues.First()) : null;
        }
    }
}