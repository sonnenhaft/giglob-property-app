using ApiVersioningModule.ServiceResolver.Interfaces;
using Microsoft.Practices.Unity;

namespace ApiVersioningModule.Unity.ServiceResolver
{
    public class ApiVersioningModuleUnityServiceResolver: IApiVersioningModuleServiceResolver
    {
        private readonly IUnityContainer _container;

        public ApiVersioningModuleUnityServiceResolver(IUnityContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}