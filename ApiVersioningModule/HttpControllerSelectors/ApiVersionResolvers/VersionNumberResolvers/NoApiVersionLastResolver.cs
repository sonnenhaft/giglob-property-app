using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.VersionNumberResolvers.Interfaces;

namespace ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.VersionNumberResolvers
{
    public class NoApiVersionLastResolver : INoApiVersionResolver
    {
        public int? Resolve(IEnumerable<Assembly> apiVersionAssemblies)
        {
            var versions = apiVersionAssemblies.Select(x =>
            {
                var match = Regex.Match(x.GetName()
                                         .Name, "api.v([0-9]{1,3})", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

                return int.Parse(match.Groups[1].Value);
            });

            return versions.OrderByDescending(x => x)
                           .FirstOrDefault();
        }
    }
}