using System;
using System.IO;

namespace Domain.Entities.Implementation.File
{
    public class File : IAggregateRootEntity<Guid>, IDeletableEntity, IDisposable
    {
        public File() : this(Guid.NewGuid()) { }

        public File(Guid id)
        {
            Id = id;
            CreationDate = DateTime.UtcNow;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string VirtualPath { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsDeleted { get; set; }

        public Stream Stream { get; set; }

        public void Dispose()
        {
            Stream?.Dispose();
        }
    }
}