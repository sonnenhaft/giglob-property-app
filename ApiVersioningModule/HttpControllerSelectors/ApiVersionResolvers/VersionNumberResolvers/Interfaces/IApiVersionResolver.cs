using System.Net.Http;

namespace ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.VersionNumberResolvers.Interfaces
{
    public interface IApiVersionResolver
    {
        int? Resolve(HttpRequestMessage request);
    }
}