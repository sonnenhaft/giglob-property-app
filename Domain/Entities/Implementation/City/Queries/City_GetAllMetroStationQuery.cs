using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CQRS;
using Domain.Repositories;

namespace Domain.Entities.Implementation.City.Queries
{
    public class City_GetAllMetroStationQuery : IQuery
    {
        public long Id { get; set; }

        public City_GetAllMetroStationQuery(long id)
        {
            Id = id;
        }
    }

    public class City_GetAllMetroStationQueryHandler : IQueryHandler<City_GetAllMetroStationQuery, IEnumerable<MetroStation>>
    {
        private readonly ICityRepository _cityRepository;

        public City_GetAllMetroStationQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IEnumerable<MetroStation> Handle(City_GetAllMetroStationQuery query)
        {
            List<MetroStation> metroStations = new List<MetroStation>();

            var city = _cityRepository.GetAll().Where(x=>x.Id == query.Id).Include(x=>x.MetroStations).FirstOrDefault();
            if (city != null)
            {
                metroStations = city.MetroStations.ToList();
            }

            return metroStations;
        }
    }
}