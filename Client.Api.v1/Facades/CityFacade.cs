using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Client.Api.v1.Models.Models.City;
using Client.Api.v1.Models.Models.Home;
using CQRS;
using Domain.Entities.Implementation.City;
using Domain.Entities.Implementation.City.Queries;
using ExpressMapper.Extensions;

namespace Client.Api.v1.Facades
{
    public class CityFacade
    {
        private readonly IQueryHandler<City_GetAllMetroStationQuery, IEnumerable<MetroStation>> _cityGetAllMetroStationQueryHandler;
        private readonly IQueryHandler<City_GetAllDistrictsQuery, IEnumerable<District>> _cityGetAllDistrictsQueryHandler;

        public CityFacade(IQueryHandler<City_GetAllMetroStationQuery, IEnumerable<MetroStation>> cityGetAllMetroStationQueryHandler, IQueryHandler<City_GetAllDistrictsQuery, IEnumerable<District>> cityGetAllDistrictsQueryHandler)
        {
            _cityGetAllMetroStationQueryHandler = cityGetAllMetroStationQueryHandler;
            _cityGetAllDistrictsQueryHandler = cityGetAllDistrictsQueryHandler;
        }

        public IEnumerable<NearMetroStationModel> GetAllMetroStations(long id)
        {
            List<MetroStation> query = _cityGetAllMetroStationQueryHandler.Handle(new City_GetAllMetroStationQuery(id)).ToList();

            var model = new List<NearMetroStationModel>();

            for (int i = 0; i < query.Count; i++)
            {
                var branches = query[i].Branches.Select((t, y) => new NearMetroStationModel
                {
                    Name = query[i].Name,
                    Id = query[i].Id,
                    HexColor = t.HexColor,
                    MetroBranchId = t.Id
                }).ToList();

                model.AddRange(branches);
            }

            return model;
        }
    }
}