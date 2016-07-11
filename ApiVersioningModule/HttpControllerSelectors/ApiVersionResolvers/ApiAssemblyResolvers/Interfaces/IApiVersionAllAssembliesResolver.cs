using System.Collections.Generic;
using System.Reflection;

namespace ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.ApiAssemblyResolvers.Interfaces
{
    public interface IApiVersionAllAssembliesResolver
    {
        IEnumerable<Assembly> Resolve();
    }
}