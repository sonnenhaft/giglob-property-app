using System.Collections.Generic;
using System.Reflection;

namespace ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.VersionNumberResolvers.Interfaces
{
    public interface INoApiVersionResolver
    {
        int? Resolve(IEnumerable<Assembly> apiVersionAssemblies);
    }
}