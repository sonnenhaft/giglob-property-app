using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Client.Api.v1.Facades;
using Client.Api.v1.Models.Models;
using Client.Api.v1.Models.Models.City;
using Client.Api.v1.Models.Models.Home;
using Client.Api.v1.Models.Models.Home.ResponseExamples;
using Domain.Entities.Implementation.City;
using Domain.Repositories;
using SwaggerResponseExampleModule;

namespace Client.Api.v1.Controllers
{
    public class HomeController: ApiController
    {
        private readonly DataFacade _dataFacade;
        private readonly CityFacade _cityFacade;

        public HomeController(DataFacade dataFacade, CityFacade cityFacade)
        {
            _dataFacade = dataFacade;
            _cityFacade = cityFacade;
        }

        [HttpGet]
        [SwaggerResponseExampleProvider(typeof(DataModelResponseExample))]
        public IHttpActionResult GetData()
        {
            return Ok(_dataFacade.GetData());
        }

        [HttpGet]
        [SwaggerResponseExampleProvider(typeof(DataModelResponseExample))]
        public IHttpActionResult MetroStations(long cityid)
        {
            return Ok(_cityFacade.GetAllMetroStations(cityid));
        }

        [HttpGet]
        [SwaggerResponseExampleProvider(typeof(DataModelResponseExample))]
        public IHttpActionResult Districts(long cityid)
        {
            return Ok(_cityFacade.GetAllDistricts(cityid));
        }
    }
}