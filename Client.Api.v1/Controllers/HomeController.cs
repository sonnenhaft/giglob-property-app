﻿using System;
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

        public HomeController(DataFacade dataFacade)
        {
            _dataFacade = dataFacade;
        }

        [HttpGet]
        [SwaggerResponseExampleProvider(typeof(DataModelResponseExample))]
        public IHttpActionResult GetData()
        {
            return Ok(_dataFacade.GetData());
        }
    }
}