using System.Data.Entity;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.Persistence.EntityFramework.Repositories.Implementation
{
    public class EntityFrameworkRepository<TEntity, TId>: IRepository<TEntity, TId>
        where TEntity : class, IAggregateRootEntity<TId>
    {
        protected readonly DbContext DbContext;

        public EntityFrameworkRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            DbContext.Set<TEntity>()
                      .Add(entity);
        }

        public TEntity Get(TId id)
        {
            return DbContext.Set<TEntity>()
                             .Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>();
        }

        public void Remove(TEntity entity)
        {
            DbContext.Set<TEntity>()
                      .Remove(entity);
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}