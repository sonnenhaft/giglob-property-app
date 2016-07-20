using System;
using System.Linq;
using Domain.Repositories;
using Domain.Storages;

namespace Domain.Persistance.File.Implementation
{
    public class FileRepositoryStreamSetupable: IFileRepository
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

            if(file.Stream == null)
            {
                file.Stream = _fileStorage.Get(file.VirtualPath);
            }

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
    }
}