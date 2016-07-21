using System.Collections.Generic;

namespace Domain.Entities.Implementation.City
{
    public class MetroBranch
    {
        public long Id { get; set; }

        public long CityId { get; set; }

        public string HexColor { get; set; }

        public virtual ICollection<MetroBranchStation> MetroStations { get; set; }
    }
}