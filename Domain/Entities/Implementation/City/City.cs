using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain.Entities.Implementation.City
{
    public class City: IAggregateRootEntity<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<District> Districts { get; set; }

        public virtual ICollection<MetroStation> MetroStations { get; set; }

        public virtual ICollection<MetroBranch> MetroBranches { get; set; }
    }
}