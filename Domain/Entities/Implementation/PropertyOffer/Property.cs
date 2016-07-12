using System.Collections.Generic;
using System.Data.Entity.Spatial;
using Domain.Entities.Implementation.City;
using Domain.Entities.Implementation.Property.Enums;

namespace Domain.Entities.Implementation.Property
{
    public class Property
    {
        public long Id { get; set; }

        public long? OwnerId { get; set; }

        public long CityId { get; set; }

        public long? DistrictId { get; set; }

        public DbGeography Location { get; set; }

        public string Address { get; set; }

        public int Level { get; set; }

        public double AreaSize { get; set; }

        public int RoomCount { get; set; }

        public PropertyType Type { get; set; }

        public BuildingCategory BuildingCategory { get; set; }

        public virtual User Owner { get; set; }

        public virtual City.City City { get; set; }

        public virtual District District { get; set; }

        public virtual ICollection<PropertyNearMetroStation> NearMetroStations { get; set; }

        public virtual ICollection<PropertyPhoto> Photos { get; set; }

        public virtual ICollection<PropertyDocument> Documents { get; set; }
    }
}