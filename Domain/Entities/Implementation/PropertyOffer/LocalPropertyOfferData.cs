using System.Collections.Generic;
using Domain.Entities.Implementation.City;
using Domain.Entities.Implementation.PropertyOffer.Enums;

namespace Domain.Entities.Implementation.PropertyOffer
{
    public class LocalPropertyOfferData
    {
        public long PropertyOfferId { get; set; }

        public long? OwnerId { get; set; }

        public long CityId { get; set; }

        public long? DistrictId { get; set; }

        public BuildingCategory BuildingCategory { get; set; }

        public virtual User.User Owner { get; set; }

        public virtual City.City City { get; set; }

        public virtual District District { get; set; }

        public virtual ICollection<PropertyNearMetroStation> NearMetroStations { get; set; }

        public virtual ICollection<PropertyPhoto> Photoes { get; set; }

        public virtual ICollection<PropertyDocument> Documents { get; set; }
    }
}