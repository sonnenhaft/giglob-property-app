﻿using System.Web.Http;
using Client.Api.v1.Facades;
using Client.Api.v1.Models.Models.Common.ResponseExamples;
using Client.Api.v1.Models.Models.PropertyOffer;
using Client.Api.v1.Models.Models.PropertyOffer.Examples;
using Client.Api.v1.Models.Models.PropertyOffer.ResponseExamples;
using SwaggerResponseExampleModule;

namespace Client.Api.v1.Controllers
{
    public class PropertyOfferController : ApiController
    {
        private readonly PropertyOfferFacade _propertyOfferFacade;

        public PropertyOfferController(PropertyOfferFacade propertyOfferFacade)
        {
            _propertyOfferFacade = propertyOfferFacade;
        }

        [HttpPost]
        [Authorize]
        [SwaggerResponseExampleProvider(typeof (SuccessResponseExample))]
        public IHttpActionResult Create(PropertyOfferCreateRequestModel reqModel)
        {
            _propertyOfferFacade.Create(reqModel);

            return Ok();
        }

        [HttpGet]
        [SwaggerResponseExampleProvider(typeof (PropertyOfferGetAllResponseExample))]
        public IHttpActionResult GetAll([FromUri(Name = "")] PropertyOfferGetAllOffersRequestModel reqModel)
        {
            return Ok(_propertyOfferFacade.GetAll(reqModel));
        }

        [SwaggerResponseExampleProvider(typeof (PropertyOfferGetResponseExample))]
        public IHttpActionResult Get([FromUri(Name = "")] PropertyOfferGetRequestModel reqModel)
        {
            return Ok(_propertyOfferFacade.Get(reqModel));
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult MyOffers()
        {
            return Ok(_propertyOfferFacade.GetCurrentUserOffers());
        }
    }
}