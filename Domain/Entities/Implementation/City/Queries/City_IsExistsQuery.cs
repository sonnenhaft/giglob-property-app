using CQRS;
using Domain.Repositories;

namespace Domain.Entities.Implementation.City.Queries
{
    public class City_IsExistsQuery : IQuery
    {
        public City_IsExistsQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }

    public class City_IsExistsQueryHandler : IQueryHandler<City_IsExistsQuery, bool>
    {
        private readonly ICityRepository _cityRepository;

        public City_IsExistsQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public bool Handle(City_IsExistsQuery query)
        {
            return _cityRepository.IsExists(query.Id);
        }
    }
}