using System;
using System.Collections.Generic;
using System.Web.Http;
using Client.Api.v1.Facades;
using Client.Api.v1.Models.Models.City;
using Client.Api.v1.Models.Models.Common;
using Client.Api.v1.Models.Models.Common.ResponseExamples;
using Client.Api.v1.Models.Models.PropertyOffer;
using Client.Api.v1.Models.Models.PropertyOffer.Examples;
using Domain.Entities.Implementation.PropertyOffer.Enums;
using SwaggerResponseExampleModule;

namespace Client.Api.v1.Controllers
{
    public class PropertyOfferController: ApiController
    {
        private readonly PropertyOfferFacade _propertyOfferFacade;

        public PropertyOfferController(PropertyOfferFacade propertyOfferFacade)
        {
            _propertyOfferFacade = propertyOfferFacade;
        }

        [HttpPost]
        [SwaggerResponseExampleProvider(typeof(SuccessResponseExample))]
        public IHttpActionResult Create(PropertyOfferCreateRequestModel reqModel)
        {
            _propertyOfferFacade.Create(reqModel);

            return Ok();
        }

        [HttpGet]
        [SwaggerResponseExampleProvider(typeof(PropertyOfferGetResponseExample))]
        public IHttpActionResult Get(IdentifyModel<long> reqModel)
        {
            return Ok(new PropertyOfferGetResponseExample().GetResponseExample());
        }
    }
}