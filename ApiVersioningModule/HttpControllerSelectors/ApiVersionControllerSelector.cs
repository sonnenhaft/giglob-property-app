using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.VersionNumberResolvers.Interfaces;

namespace ApiVersioningModule.HttpControllerSelectors
{
    public class ApiVersionControllerSelector : DefaultHttpControllerSelector
    {
        private readonly HttpConfiguration _config;
        private readonly IApiVersionResolver _apiVersionResolver;
        private readonly INoApiVersionResolver _noApiVersionResolver;
        private readonly Lazy<Dictionary<string, HttpControllerDescriptor>> _controllerDescriptors;

        private readonly Lazy<IEnumerable<Assembly>> _apiVersionAssemblies;

        public ApiVersionControllerSelector(HttpConfiguration configuration, IApiVersionResolver apiVersionResolver, INoApiVersionResolver noApiVersionResolver) : base(configuration)
        {
            _config = configuration;
            _apiVersionResolver = apiVersionResolver;
            _noApiVersionResolver = noApiVersionResolver;

            _apiVersionAssemblies = new Lazy<IEnumerable<Assembly>>(ResolveApiVersionAssemblies);
            _controllerDescriptors = new Lazy<Dictionary<string, HttpControllerDescriptor>>(InitializeControllerDescriptors);
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var version = _apiVersionResolver.Resolve(request) ?? _noApiVersionResolver.Resolve(_apiVersionAssemblies.Value);

            if (!version.HasValue)
            {
                return null;
            }

            var controllerName = GetControllerName(request);
            var type = GetControllerType(version.Value, controllerName);

            return type == null ? null : new HttpControllerDescriptor(_config, controllerName, type);
        }

        public override IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            return _controllerDescriptors.Value;
        }

        private Type GetControllerType(int version, string controllerName)
        {
            var currVersionAssembly = ResolveApiVersionAssembly(_apiVersionAssemblies.Value, version);

            var type = currVersionAssembly != null
                ? currVersionAssembly.GetTypes()
                                     .FirstOrDefault(
                                         x =>
                                             !x.IsAbstract && typeof (IHttpController).IsAssignableFrom(x)
                                             && string.Equals(x.Name, string.Format("{0}{1}", controllerName, ControllerSuffix), StringComparison.InvariantCultureIgnoreCase))
                : null;

            return type;
        }

        private Assembly ResolveApiVersionAssembly(IEnumerable<Assembly> apiVersionAssemblies, int version)
        {
            return apiVersionAssemblies.FirstOrDefault(
                x => Regex.IsMatch(
                    x.GetName()
                     .Name,
                    "api.v" + version,
                    RegexOptions.CultureInvariant | RegexOptions.IgnoreCase));
        }

        private IEnumerable<Assembly> ResolveApiVersionAssemblies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var apiVersionAssemblies = assemblies.Where(
                x => Regex.IsMatch(
                    x.GetName()
                     .Name,
                    "api.v([0-9]{1,3})",
                    RegexOptions.CultureInvariant | RegexOptions.IgnoreCase));

            return apiVersionAssemblies;
        }

        private Dictionary<string, HttpControllerDescriptor> InitializeControllerDescriptors()
        {
            var dictionary = new Dictionary<string, HttpControllerDescriptor>(StringComparer.OrdinalIgnoreCase);

            var assembliesResolver = _config.Services.GetAssembliesResolver();
            var controllersResolver = _config.Services.GetHttpControllerTypeResolver();
            var controllerTypes = controllersResolver.GetControllerTypes(assembliesResolver);
            var duplicates = new List<string>();

            foreach (var controllerType in controllerTypes)
            {
                // For the dictionary key, strip "Controller" from the end of the type name.
                // This matches the behavior of DefaultHttpControllerSelector.
                var controllerName = controllerType.Name.Remove(controllerType.Name.Length - ControllerSuffix.Length);

                var key = string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}.{1}",
                    controllerType.Assembly.GetName()
                                  .Name,
                    controllerName);

                // Check for duplicate keys.
                if (dictionary.Keys.Contains(key))
                {
                    if (!duplicates.Contains(key))
                    {
                        duplicates.Add(key);
                    }
                }
                else
                {
                    dictionary[key] = new HttpControllerDescriptor(_config, controllerName, controllerType);
                }
            }

            foreach (var duplicate in duplicates)
            {
                dictionary.Remove(duplicate);
            }

            return dictionary;
        }
    }
}