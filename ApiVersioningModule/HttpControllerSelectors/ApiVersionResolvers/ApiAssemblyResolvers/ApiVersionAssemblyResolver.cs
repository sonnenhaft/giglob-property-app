using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.ApiAssemblyResolvers.Interfaces;

namespace ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.ApiAssemblyResolvers
{
    public class ApiVersionAssemblyResolver : IApiVersionAssemblyResolver
    {
        public Assembly Resolve(IEnumerable<Assembly> apiVersionAssemblies, int version)
        {
            return apiVersionAssemblies.FirstOrDefault(
                x => Regex.IsMatch(
                    x.GetName()
                     .Name,
                    "api.v" + version,
                    RegexOptions.CultureInvariant | RegexOptions.IgnoreCase));
        }
    }
}