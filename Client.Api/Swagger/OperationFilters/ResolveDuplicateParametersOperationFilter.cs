using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace Client.Api.Swagger.OperationFilters
{
    public class ResolveDuplicateParametersOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters != null && operation.parameters.Any(x => operation.parameters.Count(y => string.Equals(y.name, x.name, StringComparison.InvariantCultureIgnoreCase)) > 1))
            {
                var duplicatedParametersGroups = operation.parameters.Where(
                    x =>
                        operation.parameters.Count(
                            y => string.Equals(y.name, x.name, StringComparison.InvariantCultureIgnoreCase)) > 1)
                                                          .GroupBy(x => x.name.ToLower())
                                                          .ToList();

                foreach (var duplicatedParametersGroup in duplicatedParametersGroups)
                {
                    var noDeletable = duplicatedParametersGroup.Last();

                    if (Regex.IsMatch(apiDescription.Route.RouteTemplate, @"\{" + noDeletable.name + @"\}"))
                    {
                        noDeletable.@in = "path";
                    }

                    var parametersForRemove = duplicatedParametersGroup
                        .Take(duplicatedParametersGroup.Count() - 1)
                        .ToList();

                    foreach (var parameterForRemove in parametersForRemove)
                    {
                        operation.parameters.Remove(parameterForRemove);
                    }
                }
            }
        }
    }
}