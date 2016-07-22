using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using Domain.Authentication;
using Domain.Entities.Implementation.PropertyOffer;
using Domain.Entities.Implementation.PropertyOffer.Dtos;
using ExpressMapper;
using ExpressMapper.Extensions;

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
                  .Member(offer => offer.Location, context => DbGeography.FromText(string.Format("POINT({0} {1})",
                                                                                                 context.Lon.ToString(CultureInfo.InvariantCulture),
                                                                                                 context.Lat.ToString(CultureInfo.InvariantCulture))))
                  .Member(offer => offer.LocalPropertyOfferData.OwnerId, context => currentUserService.GetId())
                  .Member(offer => offer.LocalPropertyOfferData.CityId, context => context.CityId)
                  .Member(offer => offer.LocalPropertyOfferData.DistrictId, context => context.DistrictId)
                  .Member(offer => offer.LocalPropertyOfferData.BuildingCategory, context => context.BuildingCategory)
                  .Member(offer => offer.LocalPropertyOfferData.NearMetroStations, context => context.NearMetroBranchStationIds.Select(id => new PropertyNearMetroStation {MetroBranchStationId = id}))
                  .Member(offer => offer.LocalPropertyOfferData.Photoes, context => context.Photoes)
                  .Member(offer => offer.LocalPropertyOfferData.Documents, context => context.Documents != null 
                  ? context.Documents.Select(guid => new PropertyDocument
                  {
                      FileId = guid
                  })
                  : null)
                  .Member(offer => offer.PropertyExchange, context=>context.ExchangeDetails);

            Mapper.Register<PropertyOfferCreatePhotoContext, PropertyPhoto>()
                .Member(photo => photo.FileId, context => context.Id);

            Mapper.Register<PropertyOfferExchangeContext, PropertyExchange>();
        }
    }
}