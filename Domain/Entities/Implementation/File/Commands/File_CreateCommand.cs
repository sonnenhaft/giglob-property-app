using System;
using System.IO;
using CQRS;
using Domain.Repositories;
using Domain.Storages;

namespace Domain.Entities.Implementation.File.Commands
{
    public class File_CreateCommand : ICommand
    {
        public Guid Id { get; set; }

        public Stream Stream { get; set; }

        public string FileName { get; set; }

        public File_CreateCommand(Guid id, Stream stream, string fileName)
        {
            Id = id;
            Stream = stream;
            FileName = fileName;
        }
    }

    public class File_CreateCommandHandler : ICommandHandler<File_CreateCommand>
    {
        private readonly IFileStorage _fileStorage;
        private readonly IFileRepository _fileRepository;

        public File_CreateCommandHandler(IFileStorage fileStorage, IFileRepository fileRepository)
        {
            _fileStorage = fileStorage;
            _fileRepository = fileRepository;
        }

        public void Handle(File_CreateCommand command)
        {
            var extension = command.FileName.Contains(".") ? command.FileName.Substring(command.FileName.LastIndexOf(".") + 1) : "";
            var file = new File(command.Id)
                       {
                           Extension = extension,
                           Name = command.FileName
                       };
            var fileName = $"{file.Id}.{extension}";
            var virtualPath = $"~/storage/{fileName}";

            _fileStorage.Create(command.Stream, virtualPath, FileMode.CreateNew);
            file.VirtualPath = virtualPath;
            _fileRepository.Add(file);
        }
    }
}