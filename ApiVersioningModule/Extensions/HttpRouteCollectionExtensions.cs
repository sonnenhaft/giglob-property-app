using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Http;

namespace ApiVersioningModule.Extensions
{
    public static class HttpRouteCollectionExtensions
    {
        public static void MapUrlVersionedHttpRoute(
            this HttpRouteCollection routes,
            string name,
            string routeTemplate,
            object defaults = null,
            object constraints = null)
        {
            var versionedRouteName = name + "Versioned";
            var versionedRouteTemplate = "v{version}/" + routeTemplate;
            var versionedConstraints = constraints == null
                ? new
                  {
                      version = @"^[0-9]{1,2}$"
                  }
                : AddProperty(constraints, "version", @"^[0-9]{1,2}$");

            routes.MapHttpRoute(versionedRouteName, versionedRouteTemplate, defaults, versionedConstraints);
            routes.MapHttpRoute(name, routeTemplate, defaults, constraints);
        }

        private static object AddProperty(object obj, string propertyName, object propertyValue)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            var properties = TypeDescriptor.GetProperties(obj);

            foreach (PropertyDescriptor property in properties)
            {
                result.Add(property.Name, property.GetValue(obj));
            }

            result.Add(propertyName, propertyValue);

            return result;
        }
    }
}