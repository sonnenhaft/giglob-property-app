using Domain.Entities;

namespace Domain.Persistence.EntityFramework.Tests.Misc.Entities
{
    public class TestEntity: IAggregateRootEntity<long>
    {
        public long Id { get; set; }
    }
}