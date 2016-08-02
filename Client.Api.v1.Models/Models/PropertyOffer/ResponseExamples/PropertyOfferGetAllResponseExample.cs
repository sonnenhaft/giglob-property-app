using System;
using System.Collections.Generic;
using Client.Api.v1.Models.Models.City;
using SwaggerResponseExampleModule.Providers.Interfaces;

namespace Client.Api.v1.Models.Models.PropertyOffer.ResponseExamples
{
    public class PropertyOfferGetAllResponseExample : ISwaggerResponseExampleProvider
    {
        public object GetResponseExample()
        {
            return new List<PropertyOfferListItemModel>
            {
                new PropertyOfferListItemModel
                {
                    AreaSize = 67,
                    StreetName = "Пушкина",
                    Cost = 1000000,
                    Id = 1,
                    Lat = 10,
                    Level = 4,
                    Lon = 15,
                    RoomCount = 2,
                    NearMetroStationModel = new NearMetroStationModel
                                            {
                                                Id = 1,
                                                Name = "Курпатовская",
                                                HexColor = "000000"
                                            },
                    Photos = new List<string> {"http://images/1.jpg", "http://images/2.jpg" }
                },
                 new PropertyOfferListItemModel
                {
                    AreaSize = 77,
                    Cost = 1000000,
                    Id = 2,
                    Lat = 12,
                    Level = 10,
                    Lon = 25,
                    StreetName = "Пушкина",
                    RoomCount = 1,
                    NearMetroStationModel = new NearMetroStationModel
                                            {
                                                Id = 1,
                                                Name = "Сокольники",
                                                HexColor = "FFFFFF"
                                            },
                    Photos = new List<string> {"http://images/6.jpg", "http://images/56.jpg" }
                }
            };
        }
    }
}