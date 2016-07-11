using System.Data.Entity;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.Persistence.EntityFramework.Repositories.Implementation
{
    public class EntityFrameworkRepository<TEntity, TId>: IRepository<TEntity, TId>
        where TEntity : class, IAggregateRootEntity<TId>
    {
        private DbContext _dbContext;

        public EntityFrameworkRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>()
                      .Add(entity);
        }

        public TEntity Get(TId id)
        {
            return _dbContext.Set<TEntity>()
                             .Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>()
                      .Remove(entity);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}