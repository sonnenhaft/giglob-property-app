using System;
using System.Linq;
using Domain.Repositories;
using Domain.Storages;

namespace Domain.Persistence.File.Implementation
{
    public class FileRepositoryStreamSetupable : IFileRepository
    {
        private readonly IFileStorage _fileStorage;
        private readonly IFileRepository _decoratee;

        public FileRepositoryStreamSetupable(IFileStorage fileStorage, IFileRepository decoratee)
        {
            _fileStorage = fileStorage;
            _decoratee = decoratee;
        }

        public void Add(Entities.Implementation.File.File entity)
        {
            _decoratee.Add(entity);
        }

        public Entities.Implementation.File.File Get(Guid id)
        {
            var file = _decoratee.Get(id);
            InjectStream(file);

            return file;
        }

        public IQueryable<Entities.Implementation.File.File> GetAll()
        {
            var files = _decoratee.GetAll();
            var result = new FileQueryableStreamSetupable(_fileStorage, files);

            return result;
        }

        public void Remove(Entities.Implementation.File.File entity)
        {
            _decoratee.Remove(entity);
        }

        public void SaveChanges()
        {
            _decoratee.SaveChanges();
        }

        public bool IsExists(Guid id)
        {
            return _decoratee.IsExists(id);
        }

        public Entities.Implementation.File.File Get(Guid id, bool includeDeleted)
        {
            var file = _decoratee.Get(id, includeDeleted);
            InjectStream(file);

            return file;
        }

        public IQueryable<Entities.Implementation.File.File> GetAll(bool includeDeleted)
        {
            var files = _decoratee.GetAll(includeDeleted);

            return new FileQueryableStreamSetupable(_fileStorage, files);
        }

        public void Restore(Entities.Implementation.File.File entity)
        {
            _decoratee.Restore(entity);
        }

        private void InjectStream(Entities.Implementation.File.File file)
        {
            if (file != null && file.Stream == null)
            {
                file.Stream = _fileStorage.Get(file.VirtualPath);
            }
        }
    }
}