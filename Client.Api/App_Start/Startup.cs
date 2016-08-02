using System;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Validation;
using ApiVersioningModule;
using ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.VersionNumberResolvers;
using Client.Api.ActionFilters;
using Client.Api.Authentication;
using Client.Api.Elmah;
using Client.Api.FluentValidation;
using Client.Api.v1;
using Domain.Authentication;
using Domain.Persistence.EntityFramework;
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
            ApiVersioningConfiguration.Configure(GlobalConfiguration.Configuration, new UrlApiVersionResolver(), new NoApiVersionLastResolver());
            RouteConfiguration.Configure(GlobalConfiguration.Configuration.Routes);
            ElmahConfiguration.Configure(GlobalConfiguration.Configuration.Services);
            JsonFormatterConfiguration.Configure(GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            ParameterBindingConfiguration.Configure(GlobalConfiguration.Configuration.ParameterBindingRules);
            AuthConfiguration.ConfigureAuth(app);
            GlobalConfiguration.Configuration.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            FluentValidationConfiguration.Configure(GlobalConfiguration.Configuration, container.GetInstance<ModelStateValidatorActionFilter>(), new SimpeInjectorValidatorFactory(container));
            GlobalConfiguration.Configuration.Filters.Add(container.GetInstance<NotFoundActionFilter>());
            MapsConfiguration.Configure(container.GetInstance<ICurrentUserService>());
        }
    }
}
