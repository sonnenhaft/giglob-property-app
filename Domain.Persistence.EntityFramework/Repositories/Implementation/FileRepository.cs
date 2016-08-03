using System;
using System.Data.Entity;
using Domain.Entities.Implementation.File;
using Domain.Repositories;

namespace Domain.Persistence.EntityFramework.Repositories.Implementation
{
    public class FileRepository : DeletableEntityFrameworkRepository<File, Guid>, IFileRepository
    {
        public FileRepository(DbContext dbContext, IRepository<File, Guid> decoratee) : base(dbContext, decoratee) { }
    }
}