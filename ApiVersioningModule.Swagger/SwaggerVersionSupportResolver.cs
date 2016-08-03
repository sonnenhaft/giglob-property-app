using System.Text.RegularExpressions;
using System.Web.Http.Description;

namespace ApiVersioningModule.Swagger
{
    public class SwaggerVersionSupportResolver
    {
        public static bool Resolve(ApiDescription apiDescription, string targetApiVersion)
        {
            return Regex.IsMatch(
                apiDescription.ActionDescriptor.ControllerDescriptor.ControllerType.Assembly.GetName()
                              .Name,
                string.Format("api.v{0}", targetApiVersion),
                RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
        }
    }
}