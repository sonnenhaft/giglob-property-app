using System;
using System.IO;

namespace Domain.Entities.Implementation.File
{
    public class File
    {
        public File()
        {
            Id = Guid.NewGuid();
        }

        public File(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string MimeType { get; set; }

        public bool IsDeleted { get; set; }

        public Stream Stream { get; set; }
    }
}