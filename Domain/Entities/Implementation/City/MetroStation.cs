﻿using System.Collections.Generic;

namespace Domain.Entities.Implementation.City
{
    public class MetroStation
    {
        public long Id { get; set; }

        public long CityId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<MetroStationToMetroBranchRelations> ToMetroBranchRelations { get; set; }
    }
}