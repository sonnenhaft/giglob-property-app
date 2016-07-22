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
                new PropertyOfferDataModel(),
                new PropertyOfferDataModel(),
                new PropertyOfferDataModel(),
            };
        }
    }
}