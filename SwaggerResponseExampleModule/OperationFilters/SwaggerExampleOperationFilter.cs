using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

                if (response != null)
                {
                    AddExample(response.examples as Dictionary<string, Dictionary<string, object>>, attr.HttpStatusCode, attr.ExampleType);
                }
            }
        }

        private void AddExample(Dictionary<string, Dictionary<string, object>> examples, int statusCode, Type providerType)
        {
            if (examples == null)
            {
                examples = new Dictionary<string, Dictionary<string, object>>();
            }

            if (!examples.ContainsKey("application/json"))
            {
                examples.Add("application/json", new Dictionary<string, object>());
            }

            var statusCodeString = $"Response example for status code {statusCode}";

            if (!examples["application/json"].ContainsKey(statusCodeString))
            {
                examples["application/json"].Add(statusCodeString, null);
            }

            var provider = (ISwaggerResponseExampleProvider) Activator.CreateInstance(providerType);
            examples["application/json"][statusCodeString] = ApplySerializerSettings(provider.GetResponseExample());
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