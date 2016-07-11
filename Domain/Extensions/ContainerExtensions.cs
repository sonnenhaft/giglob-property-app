using ConquerorsFramework;
using Domain.UnitOfWork.CQRS.Decorators;
using SimpleInjector;

namespace Domain.Extensions
{
    public static class ContainerExtensions
    {
        public static void RegisterDomainDependencies(this Container container)
        {
            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(CommandHandlerUnitOfWorkDecorator<>), Lifestyle.Transient);
        }
    }
}