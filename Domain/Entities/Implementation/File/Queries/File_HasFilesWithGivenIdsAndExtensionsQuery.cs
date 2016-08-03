using System;
using System.Collections.Generic;
using System.Linq;
using CQRS;
using Domain.Repositories;

namespace Domain.Entities.Implementation.File.Queries
{
    public class File_HasFilesWithGivenIdsAndExtensionsQuery : IQuery
    {
        public File_HasFilesWithGivenIdsAndExtensionsQuery(IEnumerable<Guid> ids, IEnumerable<string> allowedExtensions)
        {
            Ids = ids;
            AllowedExtensions = allowedExtensions.Select(extension => extension.ToLower());
        }

        public IEnumerable<Guid> Ids { get; set; }

        public IEnumerable<string> AllowedExtensions { get; set; }
    }

    public class File_HasFilesWithGivenIdsAndExtensionsQueryHandler : IQueryHandler<File_HasFilesWithGivenIdsAndExtensionsQuery, bool>
    {
        private readonly IFileRepository _fileRepository;

        public File_HasFilesWithGivenIdsAndExtensionsQueryHandler(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public bool Handle(File_HasFilesWithGivenIdsAndExtensionsQuery query)
        {
            if (query.Ids == null || !query.Ids.Any())
            {
                return true;
            }

            if (query.AllowedExtensions == null || !query.AllowedExtensions.Any())
            {
                return false;
            }

            var allowedFileIds = _fileRepository.GetAll()
                                                .Where(file => query.AllowedExtensions.Contains(file.Extension.ToLower()))
                                                .Select(file => file.Id);

            return query.Ids.All(id => allowedFileIds.Contains(id));
        }
    }
}