using System.Web;
using System.Web.Http;
using Client.Api.Authentication.Extensions;
using Client.Api.v1.Extensions;
using Domain.Extensions;
using Domain.Persistence.EntityFramework.Extensions;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Integration.WebApi;

namespace Client.Api
{
    public class SimpleInjectorConfiguration
    {
        public static void Configure(Container container)
        {
            container.Options.DefaultScopedLifestyle = Lifestyle.CreateHybrid(
                () => HttpContext.Current != null,
                new WebApiRequestLifestyle(),
                new ExecutionContextScopeLifestyle());
            container.RegisterDomainDependencies();
            container.RegisterDomainPersistenceEntityFrameworkDependencies();
            container.RegisterClientApiAuthenticationDependencies();
            container.RegisterClientApiV1Dependencies();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}