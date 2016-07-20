using System.Security.Cryptography.X509Certificates;
using Client.Api.v1.Models.Models.City;
using Domain.Entities.Implementation.City;
using Client.Api.v1.Models.Models.User;
using Domain.Entities.User.Implementation;

using ExpressMapper;

namespace Client.Api.v1
{
    public class MapsConfiguration
    {
        public static void Configure()
        {
            Mapper.Register<City, CityModel>();

            Mapper.Register<MetroStationToMetroBranchRelations, NearMetroStationModel>()
            .Member(x => x.HexColor, y => y.MetroBranch.HexColor)
            .Member(x => x.Id, y => y.MetroStationId)
            .Member(x => x.MetroBranchId, y => y.MetroBranchId)
            .Member(x => x.Name, y => y.MetroStation.Name);

            Mapper.Register<User, UserModel>();
        }
    }
}