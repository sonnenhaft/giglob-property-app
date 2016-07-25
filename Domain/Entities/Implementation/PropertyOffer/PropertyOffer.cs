using System;
using System.Data.Entity.Spatial;
using Domain.Entities.Implementation.PropertyOffer.Enums;

namespace Domain.Entities.Implementation.PropertyOffer
{
    public class PropertyOffer: IAggregateRootEntity<long>, IDeletableEntity
    {
        public PropertyOffer()
        {
            CreationDate = DateTime.UtcNow;
        }

        public long Id { get; set; }

        public decimal Cost { get; set; }

        public string Comment { get; set; }

        public DateTime CreationDate { get; set; }

        public OfferType OfferType { get; set; }

        public DbGeography Location { get; set; }

        public string StreetName { get; set; }

        public string HouseNumber { get; set; }

        public string Housing { get; set; }

        public string ApartmentNumber { get; set; }

        public int Level { get; set; }

        public double AreaSize { get; set; }

        public int RoomCount { get; set; }

        public PropertyType Type { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsLocal { get; set; }

        public virtual LocalPropertyOfferData LocalPropertyOfferData { get; set; }

        public virtual ExternalPropertyOfferData ExternalPropertyOfferData { get; set; }

        public long? PropertyExchangeId { get; set; }
        public virtual PropertyExchangeDetails PropertyExchangeDetails { get; set; }
    }
}