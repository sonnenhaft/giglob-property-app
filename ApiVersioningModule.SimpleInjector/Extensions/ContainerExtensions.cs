using ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.ApiAssemblyResolvers;
using ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.ApiAssemblyResolvers.Interfaces;
using SimpleInjector;

namespace ApiVersioningModule.SimpleInjector.Extensions
{
    public static class ContainerExtensions
    {
         public static void RegisterApiVersioningModuleDependencies(this Container container)
        {
            container.Register<IApiVersionAssemblyResolver, ApiVersionAssemblyResolver>();
            container.Register<IApiVersionAllAssembliesResolver, ApiVersionAllAssembliesResolver>();
        }
    }
}