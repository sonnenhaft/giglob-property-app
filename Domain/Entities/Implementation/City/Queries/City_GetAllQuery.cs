using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CQRS;
using Domain.Repositories;

namespace Domain.Entities.Implementation.City.Queries
{
    public class City_GetAllQuery : IQuery { }

    public class City_GetAllQueryHandler : IQueryHandler<City_GetAllQuery, IEnumerable<City>>
    {
        private readonly ICityRepository _cityRepository;

        public City_GetAllQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IEnumerable<City> Handle(City_GetAllQuery query)
        {
            var cities = _cityRepository.GetAll()
                                        .Include(x => x.Districts)
                                        .ToList();

            return cities;
        }
    }
}