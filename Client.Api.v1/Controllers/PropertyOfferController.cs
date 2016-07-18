using System.Web.Http;
using Client.Api.v1.Models.Models.Common.ResponseExamples;
using Client.Api.v1.Models.Models.PropertyOffer;
using SwaggerResponseExampleModule;

namespace Client.Api.v1.Controllers
{
    public class PropertyOfferController: ApiController
    {
        [HttpPost]
        [SwaggerResponseExampleProvider(typeof(SuccessResponseExample))]
        public IHttpActionResult Create(PropertyOfferCreateRequestModel reqModel)
        {
            return Ok();
        }
    }
}