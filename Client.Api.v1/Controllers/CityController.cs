using System.Web.Http;
using Client.Api.v1.Facades;
using Client.Api.v1.Models.Models.City;
using Client.Api.v1.Models.Models.Home.ResponseExamples;
using SwaggerResponseExampleModule;

namespace Client.Api.v1.Controllers
{
    public class CityController : ApiController
    {
        private readonly CityFacade _cityFacade;

        public CityController(CityFacade cityFacade)
        {
            _cityFacade = cityFacade;
        }

        [HttpGet]
        [SwaggerResponseExampleProvider(typeof (StationModelResponseExample))]
        public IHttpActionResult MetroStations([FromUri(Name = "")] AutocompleteStationsModel<long> reqModel)
        {
            return Ok(_cityFacade.GetAllMetroStations(reqModel.Id, reqModel.StationName));
        }
    }
}