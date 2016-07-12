using System.Data.Entity;
using Domain.Entities.Implementation.City;
using Domain.Persistence.EntityFramework.Repositories.Implementation;
using Domain.Persistence.EntityFramework.UnitOfWork.Implementation;
using Domain.Repositories;
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

            container.Register(typeof(IRepository<,>), typeof(EntityFrameworkRepository<,>));
            container.Register(typeof(ICityRepository), typeof(EntityFrameworkRepository<,>));
        }
    }
}