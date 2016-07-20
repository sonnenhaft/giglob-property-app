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
            Mapper.Register<User, UserModel>();
        }
    }
}
