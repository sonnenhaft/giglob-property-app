using Client.Api.v1.Models.Models.City;
using Domain.Entities.Implementation.City;
using ExpressMapper;

namespace Client.Api.v1
{
    public class MapsConfiguration
    {
        public static void Configure()
        {
            Mapper.Register<City, CityModel>();
            Mapper.Register<MetroStation, MetroStationModel>();
        }
    }
}