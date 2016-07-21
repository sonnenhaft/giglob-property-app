using System.Linq;
using Domain.Persistence.File.Implementation;
using Domain.Repositories;
using SimpleInjector;

namespace Domain.Persistence.File.Extensions
{
    public static class ContainerExtensions
    {
        public static void RegisterDomainPersistanceFileDependencies(this Container container)
        {
            container.RegisterDecorator(typeof(IFileRepository), typeof(FileRepositoryStreamSetupable), Lifestyle.Transient);
        }
    }
}