using System.Linq;
using Domain.Authentication;
using Domain.Entities.Implementation.PropertyOffer;
using Domain.Entities.Implementation.PropertyOffer.Dtos;
using ExpressMapper;

namespace Domain
{
    public class MapsConfiguration
    {
        public static void Configure(ICurrentUserService currentUserService)
        {
            ConfigurePropertyOffer(currentUserService);
        }

        private static void ConfigurePropertyOffer(ICurrentUserService currentUserService)
        {
            Mapper.Register<PropertyOfferCreateContext, PropertyOffer>()
                  .Before((context, offer) => offer.LocalPropertyOfferData = new LocalPropertyOfferData())
                  .Member(offer => offer.IsLocal, context => true)
                  .Member(offer => offer.LocalPropertyOfferData.OwnerId, context => currentUserService.GetId())
                  .Member(offer => offer.LocalPropertyOfferData.CityId, context => context.CityId)
                  .Member(offer => offer.LocalPropertyOfferData.DistrictId, context => context.DistrictId)
                  .Member(offer => offer.LocalPropertyOfferData.BuildingCategory, context => context.BuildingCategory)
                  .Member(
                      offer => offer.LocalPropertyOfferData.NearMetroStations,
                      context => context.NearMetroBranchStationIds != null
                          ? context.NearMetroBranchStationIds.Select(
                              id => new PropertyNearMetroStation
                                    {
                                        MetroBranchStationId = id
                                    })
                          : null)
                  .Member(offer => offer.LocalPropertyOfferData.Photoes, context => context.Photoes)
                  .Member(
                      offer => offer.LocalPropertyOfferData.Documents,
                      context => context.Documents != null
                          ? context.Documents.Select(
                              guid => new PropertyDocument
                                      {
                                          FileId = guid
                                      })
                          : null)
                  .Member(offer => offer.PropertyExchangeDetails, context => context.ExchangeDetails)
                  .Ignore(offer => offer.Location);

            Mapper.Register<PropertyOfferCreatePhotoContext, PropertyPhoto>()
                  .Member(photo => photo.FileId, context => context.Id);

            Mapper.Register<PropertyOfferExchangeContext, PropertyExchangeDetails>();
        }
    }
}