using Client.Api.v1.Models.Models.City;
using Client.Api.v1.Models.Models.City;
using Client.Api.v1.Models.Models.PropertyOffer;
using System.Security.Cryptography.X509Certificates;
using Client.Api.v1.Models.Models.City;
using Domain.Entities.Implementation.City;
using Client.Api.v1.Models.Models.User;
using Domain.Entities.Implementation.PropertyOffer;
using Domain.Entities.User.Implementation;

using Domain.Entities.Implementation.PropertyOffer.Dtos;
using ExpressMapper;

namespace Client.Api.v1
{
    public class MapsConfiguration
    {
        public static void Configure()
        {
            Mapper.Register<City, CityModel>();

            Mapper.Register<MetroBranchStation, NearMetroStationModel>()
            .Member(x => x.HexColor, y => y.MetroBranch.HexColor)
            .Member(x => x.Id, y => y.Id)
            .Member(x => x.Name, y => y.MetroStation.Name);

            Mapper.Register<User, UserModel>();
            Mapper.Register<PropertyOfferCreateRequestModel, PropertyOfferCreateContext>();
            Mapper.Register<PropertyOfferCreatePhotoRequestModel, PropertyOfferCreatePhotoContext>();
            Mapper.Register<PropertyOfferCreateNearMetroStationRequestModel, PropertyOfferCreateNearMetroStationContext>();
        }
    }
}
