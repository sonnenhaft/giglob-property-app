using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace ApiVersioningModule.Swagger
{
    public class SwaggerPathsWithoutUrlVersionDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            if (swaggerDoc.paths.Any(x => !x.Key.Contains("{version}") && !Regex.IsMatch(x.Key, "^/v[0-9]{1,2}")))
            {
                swaggerDoc.paths = swaggerDoc.paths.Where(x => x.Key.Contains("{version}") || Regex.IsMatch(x.Key, "^/v[0-9]{1,2}"))
                                             .ToDictionary(x => x.Key, x => x.Value);
            }
        }
    }
}