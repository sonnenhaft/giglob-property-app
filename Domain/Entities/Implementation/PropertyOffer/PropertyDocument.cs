using System;

namespace Domain.Entities.Implementation.PropertyOffer
{
    public class PropertyDocument
    {
        public long PropertyOfferId { get; set; }

        public Guid FileId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual File.File File { get; set; }
    }
}