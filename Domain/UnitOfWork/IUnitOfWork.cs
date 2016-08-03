using System;

namespace Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Rollback();
        void Commit();
    }
}