using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Client.Api.v1.Models.Models.City;
using Client.Api.v1.Models.Models.Home;
using CQRS;
using Domain.Entities.Implementation.City;
using Domain.Entities.Implementation.City.Queries;
using ExpressMapper;
using ExpressMapper.Extensions;

namespace Client.Api.v1.Facades
{
    public class CityFacade
    {
        private readonly IQueryHandler<City_GetAllMetroBranchStationsQuery, IEnumerable<MetroBranchStation>> _cityGetAllMetroStationQueryHandler;

        public CityFacade(IQueryHandler<City_GetAllMetroBranchStationsQuery, IEnumerable<MetroBranchStation>> cityGetAllMetroStationQueryHandler)
        {
            _cityGetAllMetroStationQueryHandler = cityGetAllMetroStationQueryHandler;
        }

        public IEnumerable<NearMetroStationModel> GetAllMetroStations(long id, string stationName)
        {
            List<MetroBranchStation> query = _cityGetAllMetroStationQueryHandler.Handle(new City_GetAllMetroBranchStationsQuery(id, stationName)).ToList();

            return query.Select(Mapper.Map<MetroBranchStation, NearMetroStationModel>);
        }
    }
}