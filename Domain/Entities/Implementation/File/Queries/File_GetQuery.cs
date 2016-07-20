using System;
using CQRS;
using Domain.Repositories;
using Domain.Storages;

namespace Domain.Entities.Implementation.File.Queries
{
    public class File_GetQuery: IQuery
    {
        public Guid Id { get; set; }

        public File_GetQuery(Guid id)
        {
            Id = id;
        }
    }

    public class File_GetQueryHandler: IQueryHandler<File_GetQuery, File>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IFileStorage _fileStorage;

        public File_GetQueryHandler(IFileRepository fileRepository, IFileStorage fileStorage)
        {
            _fileRepository = fileRepository;
            _fileStorage = fileStorage;
        }

        public File Handle(File_GetQuery query)
        {
            var file = _fileRepository.Get(query.Id);

            if(file == null)
            {
                throw new ArgumentException("File not found");
            }

            return file;
        }
    }
}