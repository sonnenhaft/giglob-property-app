using System.Web.Http;
using ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.ApiAssemblyResolvers;
using ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.ApiAssemblyResolvers.Interfaces;
using ApiVersioningModule.HttpControllerSelectors.ApiVersionResolvers.VersionNumberResolvers.Interfaces;
using Microsoft.Practices.Unity;

namespace ApiVersioningModule.Unity.Extensions
{
    public static class UnityContainerExtensions
    {
        public static void RegisterApiVersioningModuleDependencies(this IUnityContainer container)
        {
            container.RegisterType<IApiVersionAssemblyResolver, IApiVersionAssemblyResolver>();
            container.RegisterType<IApiVersionAllAssembliesResolver, ApiVersionAllAssembliesResolver>();
        }
    }
}