using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using SwaggerResponseExampleModule.Providers.Interfaces;
using Swashbuckle.Swagger;

namespace SwaggerResponseExampleModule.OperationFilters
{
    public class SwaggerExampleOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var responseAttributes = apiDescription.GetControllerAndActionAttributes<SwaggerResponseExampleProviderAttribute>();

            foreach (var attr in responseAttributes)
            {
                var response = operation.responses["200"];

                var provider = (ISwaggerResponseExampleProvider) Activator.CreateInstance(attr.ExampleType);

                if (response != null)
                {
                    AddExample(response, attr.HttpStatusCode, attr.ExampleType);
                }
            }
        }

        private void AddExample(Response response, int statusCode, Type providerType)
        {
            if (response.examples == null)
            {
                response.examples = new Dictionary<string, Dictionary<string, object>>();
            }

            var exDic = response.examples as Dictionary<string, Dictionary<string, object>>;

            if (!exDic.ContainsKey("application/json"))
            {
                exDic.Add("application/json", new Dictionary<string, object>());
            }

            var statusCodeString = $"Response example for status code {statusCode}";

            if (!exDic["application/json"].ContainsKey(statusCodeString))
            {
                exDic["application/json"].Add(statusCodeString, null);
            }

            var provider = (ISwaggerResponseExampleProvider) Activator.CreateInstance(providerType);
            exDic["application/json"][statusCodeString] = ApplySerializerSettings(provider.GetResponseExample());
        }

        private static object FormatAsJson(ISwaggerResponseExampleProvider provider)
        {
            var examples = new Dictionary<string, object>
                           {
                               {
                                   "application/json", ApplySerializerSettings(provider.GetResponseExample())
                               }
                           };

            return examples;
        }

        private static object ApplySerializerSettings(object examples)
        {
            var jsonString = JsonConvert.SerializeObject(examples, GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings);
            return JsonConvert.DeserializeObject(jsonString);
        }
    }
}