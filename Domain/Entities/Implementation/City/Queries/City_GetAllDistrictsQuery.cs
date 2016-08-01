using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CQRS;
using Domain.Repositories;

namespace Domain.Entities.Implementation.City.Queries
{
    public class City_GetAllDistrictsQuery : IQuery
    {
        public City_GetAllDistrictsQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }

    public class City_GetAllDistrictsQueryHandler : IQueryHandler<City_GetAllDistrictsQuery, IEnumerable<District>>
    {
        private readonly ICityRepository _cityRepository;

        public City_GetAllDistrictsQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IEnumerable<District> Handle(City_GetAllDistrictsQuery query)
        {
            var districts = _cityRepository.GetCityDistricts(query.Id);

            return districts;
        }
    }
}