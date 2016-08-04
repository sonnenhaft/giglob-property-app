using System.Web.Http;
using System.Web.Http.Cors;
using ApiVersioningModule;
using ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.VersionNumberResolvers;
using Client.Api;
using Client.Api.ActionFilters;
using Client.Api.Authentication;
using Client.Api.FluentValidation;
using Client.Api.v1;
using Domain.Authentication;
using Microsoft.Owin;
using Owin;
using SimpleInjector;

[assembly: OwinStartup(typeof (Startup))]

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
            GlobalConfiguration.Configuration.Filters.Add(container.GetInstance<TimeoutActionFilter>());
            MapsConfiguration.Configure(container.GetInstance<ICurrentUserService>());
        }
    }
}