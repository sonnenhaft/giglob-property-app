using System.Collections.Generic;
using Client.Api.v1.Models.Models.City;

namespace Client.Api.v1.Models.Models.Home
{
    public class StationModel
    {
        public IEnumerable<MetroStationModel> Stations { get; set; }
    }
}