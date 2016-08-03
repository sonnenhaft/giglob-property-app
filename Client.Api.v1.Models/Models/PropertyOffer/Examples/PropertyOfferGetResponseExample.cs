using System;
using System.Collections.Generic;
using Client.Api.v1.Models.Models.City;
using Domain.Entities.Implementation.PropertyOffer.Enums;
using SwaggerResponseExampleModule.Providers.Interfaces;

namespace Client.Api.v1.Models.Models.PropertyOffer.Examples
{
    public class PropertyOfferGetResponseExample : ISwaggerResponseExampleProvider
    {
        public object GetResponseExample()
        {
            return new PropertyOfferModel
                   {
                       Id = 1,
                       CityId = 1,
                       CityName = "Москва",
                       DistrictId = 1,
                       DistrictName = "Арбат",
                       StreetName = "Покровская",
                       HouseNumber = "23",
                       Housing = "1",
                       ApartmentNumber = "243",
                       AreaSize = 61,
                       Cost = 23000000,
                       Comment =
                           "Продается однокомнатная квартира. Все удобства, все есть, все очень круто, метро рядом, алкодьюти напротив дома, бла-бла-бла, шуметь можно, соседей нет.",
                       CreationDate = DateTime.UtcNow.AddDays(-1),
                       Lat = 32,
                       Lon = 21,
                       Level = 7,
                       OfferType = OfferType.Sale,
                       OwnerUploadedDocuments = true,
                       RoomCount = 2,
                       Type = PropertyType.Resale,
                       NearMetroStationModel = new NearMetroStationModel
                                               {
                                                   Id = 1,
                                                   Name = "Метростанционная",
                                                   HexColor = "f9f9f9"
                                               },
                       PhotoUrls = new List<string>
                                   {
                                       "http://url.com/1",
                                       "http://url.com/2"
                                   }
                   };
        }
    }
}