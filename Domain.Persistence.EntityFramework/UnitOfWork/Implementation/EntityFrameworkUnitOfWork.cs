using System;
using System.Data.Entity;
using Domain.UnitOfWork;
using IsolationLevel = System.Data.IsolationLevel;

namespace Domain.Persistence.EntityFramework.UnitOfWork.Implementation
{
    public class EntityFrameworkUnitOfWork: IUnitOfWork
    {
        private readonly DbContextTransaction _transaction;
        private readonly DbContext _dbContext;

        public EntityFrameworkUnitOfWork(DbContext dbContext, IsolationLevel isolationLevel)
        {
            _dbContext = dbContext;
            _transaction = dbContext.Database.BeginTransaction(isolationLevel);
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();

            try
            {
                _transaction.Commit();
            }
            catch(Exception)
            {
                Rollback();
            }
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}