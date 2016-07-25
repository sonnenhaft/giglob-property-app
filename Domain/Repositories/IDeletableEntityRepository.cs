using System.Linq;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IDeletableEntityRepository<TEntity, TId>: IRepository<TEntity, TId>
        where TEntity : IAggregateRootEntity<TId>, IDeletableEntity
    {
        TEntity Get(TId id, bool includeDeleted);

        IQueryable<TEntity> GetAll(bool includeDeleted);

        void Restore(TEntity entity);
    }
}