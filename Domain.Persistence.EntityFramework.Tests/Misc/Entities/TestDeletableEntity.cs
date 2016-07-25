using Domain.Entities;

namespace Domain.Persistence.EntityFramework.Tests.Misc.Entities
{
    public class TestDeletableEntity: IAggregateRootEntity<long>, IDeletableEntity
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}