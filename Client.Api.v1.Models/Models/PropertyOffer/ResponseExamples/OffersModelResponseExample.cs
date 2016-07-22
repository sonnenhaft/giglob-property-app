using System;
using System.Collections.Generic;
using SwaggerResponseExampleModule.Providers.Interfaces;

namespace Client.Api.v1.Models.Models.PropertyOffer.ResponseExamples
{
    public class OffersModelResponseExample : ISwaggerResponseExampleProvider
    {
        public object GetResponseExample()
        {
            return new List<PropertyOfferDataModel>
            {
                new PropertyOfferDataModel
                {
                    AreaSize = 67,
                    ApartmentNumber = "6",
                    StreetName = "Пушкина",
                    Cost = 1000000,
                    HouseNumber = "56",
                    Housing = "2",
                    Id = 1,
                    Lat = 10,
                    Level = 4,
                    Lon = 15,
                    Photos = new List<string> {"http://images/1.jpg", "http://images/2.jpg" }
                },
                 new PropertyOfferDataModel
                {
                    AreaSize = 77,
                    ApartmentNumber = "36",
                    Cost = 1000000,
                    HouseNumber = "6",
                    Housing = "1б",
                    Id = 2,
                    Lat = 12,
                    Level = 10,
                    Lon = 25,
                    StreetName = "Пушкина",
                    Photos = new List<string> {"http://images/6.jpg", "http://images/56.jpg" }
                }
            };
        }
    }
}