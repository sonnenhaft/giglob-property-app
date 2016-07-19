using System;

namespace Domain.Entities.Implementation.Property
{
    public class PropertyPhoto
    {
        public long PropertyOfferId { get; set; }

        public Guid FileId { get; set; }

        public bool IsCover { get; set; }

        public bool IsDeleted { get; set; }

        public virtual File.File File { get; set; } 
    }
}