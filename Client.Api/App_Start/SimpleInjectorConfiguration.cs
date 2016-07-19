using System.Web;
using System.Web.Http;
using Domain.Extensions;
using Domain.Persistence.EntityFramework.Extensions;
using Domain.Persistence.FileStorage.Extensions;
using Domain.Tools;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Integration.WebApi;
using VirtualPathUtility = Client.Api.Tools.Implementation.VirtualPathUtility;

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
            container.RegisterDomainPersistenceFileStorageDependencies();

            container.Register<IVirtualPathUtility, VirtualPathUtility>(Lifestyle.Scoped);

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}