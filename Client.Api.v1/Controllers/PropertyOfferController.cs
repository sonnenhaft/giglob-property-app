using System;
using System.Collections.Generic;
using System.Web.Http;
using Client.Api.v1.Facades;
using Client.Api.v1.Models.Models.City;
using Client.Api.v1.Models.Models.Common;
using Client.Api.v1.Models.Models.Common.ResponseExamples;
using Client.Api.v1.Models.Models.PropertyOffer;
using Client.Api.v1.Models.Models.PropertyOffer.Examples;
using Client.Api.v1.Models.Models.PropertyOffer.ResponseExamples;
using Domain.Entities.Implementation.PropertyOffer.Enums;
using Domain.Exceptions;
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
        [SwaggerResponseExampleProvider(typeof(SuccessResponseExample))]
        public IHttpActionResult Create(PropertyOfferCreateRequestModel reqModel)
        {
            _propertyOfferFacade.Create(reqModel);

            return Ok();
        }

        [HttpGet]
        [SwaggerResponseExampleProvider(typeof(OffersModelResponseExample))]
        public IHttpActionResult GetAll([FromUri(Name = "")] PropertyOfferGetAllOffersRequestModel request)
        {
            return Ok(_propertyOfferFacade.GetAll(request));
        }

        [SwaggerResponseExampleProvider(typeof(PropertyOfferGetResponseExample))]
        public IHttpActionResult Get([FromUri(Name = "")] PropertyOfferGetRequestModel reqModel)
        {
            try
            {
                return Ok(_propertyOfferFacade.Get(reqModel));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}