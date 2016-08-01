﻿using System.Data.Entity;
using System.Linq;
using Domain.Entities;
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
            container.Register(typeof(ICityRepository), typeof(CityRepository));
            container.Register(typeof(IPropertyOfferRepository), typeof(PropertyOfferRepository));
            container.Register(typeof(IFileRepository), typeof(FileRepository));
            container.Register<IUserRepository, UserRepository>(Lifestyle.Transient);

            container.RegisterDecorator(typeof(IRepository<,>), typeof(DeletableEntityFrameworkRepository<,>), Lifestyle.Transient, context => context.ServiceType.GetGenericArguments().First().GetInterfaces().Contains(typeof(IDeletableEntity)));
        }
    }
}