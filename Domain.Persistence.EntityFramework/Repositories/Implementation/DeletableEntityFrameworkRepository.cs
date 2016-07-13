using System;
using System.Data.Entity;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.Persistence.EntityFramework.Repositories.Implementation
{
    public class DeletableEntityFrameworkRepository<TEntity, TId>: IDeletableEntityRepository<TEntity, TId>
        where TEntity : IAggregateRootEntity<TId>, IDeletableEntity
    {
        protected readonly DbContext DbContext;
        internal readonly IRepository<TEntity, TId> Decoratee;

        public DeletableEntityFrameworkRepository(DbContext dbContext, IRepository<TEntity, TId> decoratee)
        {
            DbContext = dbContext;
            Decoratee = decoratee;
        }

        public void Add(TEntity entity)
        {
            Decoratee.Add(entity);
        }

        public TEntity Get(TId id)
        {
            return Get(id, false);
        }

        public TEntity Get(TId id, bool includeDeleted)
        {
            var entity = Decoratee.Get(id);

            if (!includeDeleted && entity.IsDeleted)
            {
                throw new ArgumentException("Requested entity is deleted");
            }

            return entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return GetAll(false);
        }

        public IQueryable<TEntity> GetAll(bool includeDeleted)
        {
            var entities = Decoratee.GetAll();

            if(!includeDeleted)
            {
                entities = entities.Where(x => !x.IsDeleted);
            }

            return entities;
        }

        public void Restore(TEntity entity)
        {
            entity.IsDeleted = false;
        }

        public void Remove(TEntity entity)
        {
            entity.IsDeleted = true;
        }

        public void SaveChanges()
        {
            Decoratee.SaveChanges();
        }
    }
}