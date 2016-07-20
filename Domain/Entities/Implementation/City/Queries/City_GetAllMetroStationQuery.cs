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

    public class City_GetAllMetroStationQueryHandler : IQueryHandler<City_GetAllMetroStationQuery, IEnumerable<MetroStationToMetroBranchRelations>>
    {
        private readonly ICityRepository _cityRepository;

        public City_GetAllMetroStationQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IEnumerable<MetroStationToMetroBranchRelations> Handle(City_GetAllMetroStationQuery query)
        {
            var city = _cityRepository.GetAll().Where(x=>x.Id == query.Id).Include(x=>x.MetroStations).FirstOrDefault();

            List<MetroStationToMetroBranchRelations> metroStations = new List<MetroStationToMetroBranchRelations>();

            if (city != null)
            {
                List<ICollection<MetroStationToMetroBranchRelations>> res = city.MetroStations.Select(x => x.ToMetroBranchRelations).ToList();

                for (int i = 0; i < res.Count(); i++)
                {
                    List<MetroStationToMetroBranchRelations> items = res[i].Select(x => x).ToList();

                    metroStations.AddRange(items);
                }
            }

            return metroStations;
        }
    }
}