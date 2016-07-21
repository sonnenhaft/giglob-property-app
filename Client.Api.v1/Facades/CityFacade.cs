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
        private readonly IQueryHandler<City_GetAllMetroStationQuery, IEnumerable<MetroBranchStation>> _cityGetAllMetroStationQueryHandler;

        public CityFacade(IQueryHandler<City_GetAllMetroStationQuery, IEnumerable<MetroBranchStation>> cityGetAllMetroStationQueryHandler)
        {
            _cityGetAllMetroStationQueryHandler = cityGetAllMetroStationQueryHandler;
        }

        public IEnumerable<NearMetroStationModel> GetAllMetroStations(long id)
        {
            List<MetroBranchStation> query = _cityGetAllMetroStationQueryHandler.Handle(new City_GetAllMetroStationQuery(id)).ToList();

            return query.Select(Mapper.Map<MetroBranchStation, NearMetroStationModel>);
        }
    }
}