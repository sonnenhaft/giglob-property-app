using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Client.Api.v1.Models.Models.City;
using Client.Api.v1.Models.Models.PropertyOffer;
using Client.Api.v1.Models.Models.User;
using Domain.Entities.Implementation.City;
using Domain.Entities.Implementation.PropertyOffer;
using Domain.Entities.Implementation.PropertyOffer.Dtos;
using Domain.Entities.Implementation.PropertyOffer.Enums;
using Domain.Entities.Implementation.PropertyOffer.Queries;
using Domain.Entities.User.Implementation;
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

            Mapper.Register<PropertyOffer, PropertyOfferListItemModel>()
                  .Member(x => x.Lat, y => y.Location.Latitude)
                  .Member(x => x.Lon, y => y.Location.Longitude)
                  .Member(x => x.Photos, y => y.LocalPropertyOfferData.Photoes.Select(q => q.FileId.ToString()));

            Mapper.Register<PropertyNearMetroStation, NearMetroStationModel>()
                  .Member(model => model.Name, station => station.MetroBranchStation.MetroStation.Name)
                  .Member(model => model.HexColor, station => station.MetroBranchStation.MetroBranch != null ? station.MetroBranchStation.MetroBranch.HexColor : null);

            Mapper.Register<PropertyOfferGetAllOffersRequestModel, Offer_GetAllQuery>();
            Mapper.Register<ViewPort, ViewPortDto>();

            Mapper.Register<PropertyOffer, PropertyOfferModel>()
                  .Member(model => model.CityId, offer => offer.LocalPropertyOfferData != null ? offer.LocalPropertyOfferData.CityId : (long?) null)
                  .Member(model => model.CityName, offer => offer.LocalPropertyOfferData != null ? offer.LocalPropertyOfferData.City.Name : (string) null)
                  .Member(model => model.DistrictId, offer => offer.LocalPropertyOfferData != null ? offer.LocalPropertyOfferData.DistrictId : (long?) null)
                  .Member(
                      model => model.DistrictName,
                      offer => offer.LocalPropertyOfferData != null && offer.LocalPropertyOfferData.District != null
                          ? offer.LocalPropertyOfferData.District.Name
                          : (string) null)
                  .Member(model => model.Lat, offer => offer.Location.Latitude)
                  .Member(model => model.Lon, offer => offer.Location.Longitude)
                  .Member(model => model.OwnerUploadedDocuments, offer => offer.LocalPropertyOfferData != null && offer.LocalPropertyOfferData.Documents.Any())
                  .Member(model => model.BuildingCategory, offer => offer.IsLocal ? offer.LocalPropertyOfferData.BuildingCategory : (BuildingCategory?) null)
                  .Function(
                      model => model.PhotoUrls,
                      offer =>
                      {
                          var request = new HttpRequestMessage(HttpMethod.Get, HttpContext.Current.Request.Url)
                                        {
                                            Properties =
                                            {
                                                { HttpPropertyKeys.HttpConfigurationKey, GlobalConfiguration.Configuration },
                                                { HttpPropertyKeys.HttpRouteDataKey, new HttpRouteData(new HttpRoute()) },
                                                { "MS_HttpContext", new HttpContextWrapper(HttpContext.Current) }
                                            }
                                        };

                          var photoes = offer.LocalPropertyOfferData?.Photoes.Select(
                              photo => new UrlHelper(request).Link(
                                  "Default",
                                  new
                                  {
                                      controller = "File",
                                      action = "Get",
                                      id = photo.FileId
                                  })
                                                             .ToLower());

                          return photoes;
                      })
                  .Function(
                      model => model.NearMetroStationModel,
                      offer =>
                      {
                          var nearMetroStation = offer.LocalPropertyOfferData?.NearMetroStations.FirstOrDefault();

                          return nearMetroStation;
                      });
        }
    }
}