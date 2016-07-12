using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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
        [HttpGet]
        [SwaggerResponseExampleProvider(typeof(DataModelResponseExample))]
        public IHttpActionResult GetData()
        {
            return Ok(new DataModel
            {
                Cities = new List<CityModel>
                {
                    new CityModel
                    {
                        Id = 1,
                        Name = "Город 1",
                        Districts = new List<DistrictModel>
                        {
                            new DistrictModel
                            {
                                Id = 1,
                                Name = "Район 1"
                            },
                            new DistrictModel
                            {
                                Id = 2,
                                Name = "Район 2"
                            }
                        }
                    },
                    new CityModel
                    {
                        Id = 2,
                        Name = "Город 2",
                        Districts = new List<DistrictModel>
                        {
                            new DistrictModel
                            {
                                Id = 3,
                                Name = "Район 1"
                            },
                            new DistrictModel
                            {
                                Id = 4,
                                Name = "Район 2"
                            }
                        }
                    }
                }
            });
        }
    }
}