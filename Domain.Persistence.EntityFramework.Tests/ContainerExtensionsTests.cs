using Domain.Persistence.EntityFramework.Extensions;
using Domain.Persistence.EntityFramework.Repositories.Implementation;
using Domain.Persistence.EntityFramework.Tests.Misc.Entities;
using Domain.Repositories;
using NUnit.Framework;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;

namespace Domain.Persistence.EntityFramework.Tests
{
    [TestFixture]
    public class ContainerExtensionsTests
    {
        private Container _container;

        [SetUp]
        public void Setup()
        {
            _container = new Container();
            _container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();
        }

        [Test]
        public void RegisterDomainPersistenceEntityFrameworkDependencies_GetInstanceOfAggregateRootEntity_ReturnsEntityFrameworkRepository()
        {
            using (_container.BeginExecutionContextScope())
            {
                var expected = typeof (EntityFrameworkRepository<TestEntity, long>);
                _container.RegisterDomainPersistenceEntityFrameworkDependencies();

                var actual = _container.GetInstance(typeof (IRepository<TestEntity, long>));

                Assert.AreEqual(expected, actual.GetType());
            }
        }

        [Test]
        public void RegisterDomainPersistenceEntityFrameworkDependencies_GetInstanceOfDeletableAggregateRootEntity_ReturnsDeletableEntityEntityFrameworkRepository()
        {
            using (_container.BeginExecutionContextScope())
            {
                var expected = typeof (DeletableEntityFrameworkRepository<TestDeletableEntity, long>);
                _container.RegisterDomainPersistenceEntityFrameworkDependencies();

                var actual = _container.GetInstance(typeof (IRepository<TestDeletableEntity, long>));

                Assert.AreEqual(expected, actual.GetType());
            }
        }

        [Test]
        public void RegisterDomainPersistenceEntityFrameworkDependencies_GetInstanceOfDeletableAggregateRootEntity_ReturnsDeletableEntityEntityFrameworkRepositoryWrappedAboveEntityFrameworkRepository(
            )
        {
            using (_container.BeginExecutionContextScope())
            {
                var expected = typeof (EntityFrameworkRepository<TestDeletableEntity, long>);
                _container.RegisterDomainPersistenceEntityFrameworkDependencies();

                var actual = _container.GetInstance(typeof (IRepository<TestDeletableEntity, long>));

                Assert.AreEqual(expected, ((DeletableEntityFrameworkRepository<TestDeletableEntity, long>) actual).Decoratee.GetType());
            }
        }
    }
}