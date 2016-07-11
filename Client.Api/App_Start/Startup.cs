using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Validation;
using ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.VersionNumberResolvers;
using Client.Api.ActionFilters;
using Client.Api.FluentValidation;
using FluentValidation.WebApi;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using SimpleInjector;

[assembly: OwinStartup(typeof(Client.Api.Startup))]

namespace Client.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = new Container();
            SimpleInjectorConfiguration.Configure(container);
            ApiVersioningModule.ApiVersioningConfig.Configure(GlobalConfiguration.Configuration, new UrlApiVersionResolver(), new NoApiVersionLastResolver());
            RouteConfiguration.Configure(GlobalConfiguration.Configuration.Routes);
            GlobalConfiguration.Configuration.Filters.Add(container.GetInstance<ModelStateValidatorActionFilter>());
            GlobalConfiguration.Configuration.Services.Clear(typeof(ModelValidatorProvider));
            FluentValidationModelValidatorProvider.Configure(GlobalConfiguration.Configuration, provider => provider.ValidatorFactory = new SimpeInjectorValidatorFactory(container));
            JsonFormatterConfiguration.Configure(GlobalConfiguration.Configuration.Formatters.JsonFormatter);
        }
    }
}
