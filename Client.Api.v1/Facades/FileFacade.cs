using System;
using Client.Api.v1.Models.Models.File;
using Client.Api.v1.Results;
using CQRS;
using Domain.Entities.Implementation.File;
using Domain.Entities.Implementation.File.Commands;
using Domain.Entities.Implementation.File.Queries;

namespace Client.Api.v1.Facades
{
    public class FileFacade
    {
        private readonly ICommandHandler<File_CreateCommand> _fileCreateCommandHandler;
        private readonly IQueryHandler<File_GetQuery, File> _fileGetQueryHandler; 

        public FileFacade(ICommandHandler<File_CreateCommand> fileCreateCommandHandler, IQueryHandler<File_GetQuery, File> fileGetQueryHandler)
        {
            _fileCreateCommandHandler = fileCreateCommandHandler;
            _fileGetQueryHandler = fileGetQueryHandler;
        }

        public Guid Create(UploadingFile file)
        {
            var id = Guid.NewGuid();
            _fileCreateCommandHandler.Handle(new File_CreateCommand(id, file.Stream, file.FileName));

            return id;
        }

        public FileResult Get(Guid id)
        {
            var file = _fileGetQueryHandler.Handle(new File_GetQuery(id));

            return new FileResult(file);
        }
    }
}