using System.Linq;
using ConquerorsFramework;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRepository<TEntity, TId>
        where TEntity : IAggregateRootEntity<TId>
    {
        void Add(TEntity entity);

        TEntity Get(TId id);

        IQueryable<TEntity> GetAll();

        void Remove(TEntity entity);

        void SaveChanges();
    }
}