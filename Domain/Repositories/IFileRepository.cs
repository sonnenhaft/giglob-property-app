using System;
using Domain.Entities.Implementation.File;

namespace Domain.Repositories
{
    public interface IFileRepository : IDeletableEntityRepository<File, Guid> { }
}