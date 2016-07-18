using System.Collections.Generic;

namespace Client.Api.v1.Models.Models.City
{
    public class MetroStationModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<MetroBranchModel> Branches { get; set; }
    }
}