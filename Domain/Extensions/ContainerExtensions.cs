using CQRS;
using Domain.Repositories;
using Domain.UnitOfWork.CQRS.Decorators;
using SimpleInjector;

namespace Domain.Extensions
{
    public static class ContainerExtensions
    {
        public static void RegisterDomainDependencies(this Container container)
        {
            container.Register(typeof(IQueryHandler<,>), new [] { typeof(ContainerExtensions).Assembly });
            container.Register(typeof(ICommandHandler<>), new [] { typeof(ContainerExtensions).Assembly });

            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(CommandHandlerUnitOfWorkDecorator<>), Lifestyle.Transient);
        }
    }
}