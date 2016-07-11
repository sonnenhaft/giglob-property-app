using System.Data.Entity;
using Domain.Persistence.EntityFramework.Repositories.Implementation;
using Domain.Persistence.EntityFramework.UnitOfWork.Implementation;
using Domain.UnitOfWork;
using SimpleInjector;

namespace Domain.Persistence.EntityFramework.Extensions
{
    public static class ContainerExtensions
    {
        public static void RegisterDomainPersistenceEntityFrameworkDependencies(this Container container)
        {
            container.Register<DbContext, EntityFrameworkContext>(Lifestyle.Scoped);
            container.Register<IUnitOfWorkFactory, EntityFrameworkUnitOfWorkFactory>(Lifestyle.Transient);
        }
    }
}