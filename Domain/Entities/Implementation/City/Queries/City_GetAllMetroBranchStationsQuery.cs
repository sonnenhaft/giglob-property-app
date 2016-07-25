using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CQRS;
using Domain.Repositories;

namespace Domain.Entities.Implementation.City.Queries
{
    public class City_GetAllMetroBranchStationsQuery : IQuery
    {
        public long Id { get; set; }
        public string StationName { get; set; }

        public City_GetAllMetroBranchStationsQuery(long id, string name)
        {
            Id = id;
            StationName = name;
        }
    }

    public class City_GetAllMetroBranchStationsQueryHandler : IQueryHandler<City_GetAllMetroBranchStationsQuery, IEnumerable<MetroBranchStation>>
    {
        private readonly ICityRepository _cityRepository;

        public City_GetAllMetroBranchStationsQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IEnumerable<MetroBranchStation> Handle(City_GetAllMetroBranchStationsQuery query)
        {
            if (!_cityRepository.IsExists(query.Id))
            {
                throw new ArgumentException("City not found");
            }

            return
                _cityRepository.GetAll()
                    .Where(x => x.Id == query.Id)
                    .SelectMany(x => x.MetroStations)
                    .Where(x => x.Name.Contains(query.StationName))
                    .SelectMany(x=>x.MetroStationBranches).Select(x=>x).ToList();
        }
    }
}