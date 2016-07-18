using System.Collections.Generic;
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

        public CityFacade(IQueryHandler<City_GetAllMetroStationQuery, IEnumerable<MetroStation>> cityGetAllMetroStationQueryHandler)
        {
            _cityGetAllMetroStationQueryHandler = cityGetAllMetroStationQueryHandler;
        }

        public StationModel GetAllMetroStations(long id)
        {
            var query = _cityGetAllMetroStationQueryHandler.Handle(new City_GetAllMetroStationQuery(id));

            var model = new StationModel
            {
                Stations = query.Map<IEnumerable<MetroStation>, IEnumerable<MetroStationModel>>()
            };

            return model;
        }
    }
}