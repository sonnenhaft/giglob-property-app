using System.Web;
using System.Web.Http;
using Client.Api.Authentication.Extensions;
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
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}