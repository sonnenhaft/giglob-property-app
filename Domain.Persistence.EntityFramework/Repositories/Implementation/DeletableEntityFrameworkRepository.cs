using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
                var parameterExpr = Expression.Parameter(typeof(TEntity));
                var isDeletedPropExpr = Expression.Property(parameterExpr, "IsDeleted");
                var isDeletedExpr = Expression.Constant(false, typeof(bool));
                var eqExpr = Expression.Equal(isDeletedPropExpr, isDeletedExpr);
                var expr = Expression.Lambda<Func<TEntity, bool>>(eqExpr, parameterExpr);

                entities = entities.Where(expr);
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

        public bool IsExists(TId id)
        {
            return Decoratee.IsExists(id);
        }
    }
}