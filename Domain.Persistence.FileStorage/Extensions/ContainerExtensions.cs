using Domain.Storages;
using SimpleInjector;

namespace Domain.Persistence.FileStorage.Extensions
{
    public static class ContainerExtensions
    {
        public static void RegisterDomainPersistenceFileStorageDependencies(this Container container)
        {
            container.Register<IFileStorage, Implementation.FileStorage>(Lifestyle.Scoped);
        }
    }
}