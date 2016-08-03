using System.Collections.Generic;
using System.Reflection;

namespace ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.ApiAssemblyResolvers.Interfaces
{
    public interface IApiVersionAssemblyResolver
    {
        Assembly Resolve(IEnumerable<Assembly> apiVersionAssemblies, int version);
    }
}