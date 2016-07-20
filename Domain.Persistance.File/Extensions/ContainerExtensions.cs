using System.Linq;
using Domain.Persistance.File.Implementation;
using Domain.Repositories;
using SimpleInjector;

namespace Domain.Persistance.File.Extensions
{
    public static class ContainerExtensions
    {
        public static void RegisterDomainPersistanceFileDependencies(this Container container)
        {
            container.RegisterDecorator(typeof(IRepository<,>), context => typeof(FileRepositoryStreamSetupable), Lifestyle.Transient, context => context.ServiceType.GetGenericArguments().First() == typeof(Entities.Implementation.File.File));
            container.RegisterDecorator(typeof(IFileRepository), typeof(FileRepositoryStreamSetupable), Lifestyle.Transient);
        }
    }
}