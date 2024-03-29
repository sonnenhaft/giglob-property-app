using System;
using System.Web.Http;
using ApiVersioningModule.Swagger;
using Client.Api;
using Client.Api.Swagger.OperationFilters;
using SwaggerResponseExampleModule.OperationFilters;
using Swashbuckle.Application;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof (SwaggerConfig), "Register")]

namespace Client.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                               .EnableSwagger(
                                   c =>
                                   {
                                       c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\bin\App_Data\Client.Api.v1.XML");
                                       c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\bin\App_Data\Client.Api.v1.Models.XML");

                                       c.MultipleApiVersions(
                                           SwaggerVersionSupportResolver.Resolve,
                                           vib => { vib.Version("1", "Api v1"); });

                                       c.DocumentFilter<SwaggerUrlVersionDocumentFilter>();
                                       c.DocumentFilter<SwaggerPathsWithoutUrlVersionDocumentFilter>();

                                       c.OperationFilter<SwaggerExampleOperationFilter>();
                                       c.OperationFilter<ResolveDuplicateParametersOperationFilter>();

                                       c.UseFullTypeNameInSchemaIds();
                                   })
                               .EnableSwaggerUi(
                                   c =>
                                   {
                                       c.DisableValidator();
                                       c.EnableDiscoveryUrlSelector();
                                       c.InjectJavaScript(typeof (SwaggerConfig).Assembly, "Client.Api.Swagger.Scripts.swagger.bearer.js");
                                   });
        }
    }
}