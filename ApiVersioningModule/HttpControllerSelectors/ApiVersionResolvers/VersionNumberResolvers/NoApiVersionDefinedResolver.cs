using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.VersionNumberResolvers.Interfaces;

namespace ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.VersionNumberResolvers
{
    public class NoApiVersionDefinedResolver : INoApiVersionResolver
    {
        private readonly int _version;

        public NoApiVersionDefinedResolver(int version)
        {
            _version = version;
        }

        public int? Resolve(IEnumerable<Assembly> apiVersionAssemblies)
        {
            return apiVersionAssemblies.Any(
                x => Regex.IsMatch(
                    x.GetName()
                     .Name,
                    "api.v" + _version,
                    RegexOptions.CultureInvariant | RegexOptions.IgnoreCase))
                ? _version
                : (int?) null;
        }
    }
}