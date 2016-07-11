using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.ApiAssemblyResolvers.Interfaces;

namespace ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.ApiAssemblyResolvers
{
    public class ApiVersionAllAssembliesResolver : IApiVersionAllAssembliesResolver
    {
        public IEnumerable<Assembly> Resolve()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var apiVersionAssemblies = assemblies.Where(x => Regex.IsMatch(x.GetName()
                                                                            .Name, "api.v([0-9]{1,3})", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase));

            return apiVersionAssemblies;
        }
    }
}