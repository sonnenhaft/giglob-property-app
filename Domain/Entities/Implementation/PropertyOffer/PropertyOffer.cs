using System;
using Domain.Entities.Implementation.Property.Enums;

namespace Domain.Entities.Implementation.Property
{
    public class PropertyOffer: IAggregateRootEntity<long>, IDeletableEntity
    {
        public long Id { get; set; }

        public decimal Cost { get; set; }

        public string Comment { get; set; }

        public DateTime CreationDate { get; set; }

        public OfferType OfferType { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Property Property { get; set; }
    }
}