using System;
using System.Net;
using SwaggerResponseExampleModule.Providers.Interfaces;
using Swashbuckle.Swagger.Annotations;

namespace SwaggerResponseExampleModule
{
    public class SwaggerResponseExampleProviderAttribute : SwaggerResponseAttribute
    {
        public SwaggerResponseExampleProviderAttribute(HttpStatusCode statusCode, Type exampleType, bool useObjectAsResponseType = false) : this((int) statusCode, exampleType, useObjectAsResponseType) { }

        public SwaggerResponseExampleProviderAttribute(Type exampleType, bool useObjectAsResponseType = false) : this(200, exampleType, useObjectAsResponseType) { }

        public SwaggerResponseExampleProviderAttribute(int statusCode, Type exampleType, bool useObjectAsResponseType = false) : base(statusCode, null, null)
        {
            Type responseType = typeof (object);

            if (!useObjectAsResponseType)
            {
                var exampleProvider = Activator.CreateInstance(exampleType) as ISwaggerResponseExampleProvider;
                var example = exampleProvider.GetResponseExample();
                responseType = example.GetType();
            }

            Type = responseType;
            HttpStatusCode = statusCode;
            ExampleType = exampleType;
        }

        public int HttpStatusCode { get; set; }
        public Type ExampleType { get; set; }
    }
}