using System;
using System.Collections.Generic;
using System.Linq;
using CQRS;
using Domain.Repositories;

namespace Domain.Entities.Implementation.City.Queries
{
    public class City_ContainsMetroBranchStationsWithGivenIdsQuery: IQuery
    {
        public City_ContainsMetroBranchStationsWithGivenIdsQuery(long cityId, IEnumerable<long> metroBranchStationsIds)
        {
            CityId = cityId;
            MetroBranchStationsIds = metroBranchStationsIds;
        }

        public long CityId { get; set; }

        public IEnumerable<long> MetroBranchStationsIds { get; set; }
    }

   public class City_ContainsMetroBranchStationsWithGivenIdsQueryHandler: IQueryHandler<City_ContainsMetroBranchStationsWithGivenIdsQuery, bool>
   {
       private readonly ICityRepository _cityRepository;

       public City_ContainsMetroBranchStationsWithGivenIdsQueryHandler(ICityRepository cityRepository)
       {
           _cityRepository = cityRepository;
       }

       public bool Handle(City_ContainsMetroBranchStationsWithGivenIdsQuery query)
       {
           if(!_cityRepository.IsExists(query.CityId))
           {
               throw new ArgumentException("City not found");
           }

           if(query.MetroBranchStationsIds == null || !query.MetroBranchStationsIds.Any())
           {
               return true;
           }

           var metroBranchStationsIds = _cityRepository.GetAll()
                                                    .Where(x => x.Id == query.CityId)
                                                    .SelectMany(x => x.MetroStations)
                                                    .SelectMany(x => x.MetroStationBranches)
                                                    .Select(x => x.Id);

           return query.MetroBranchStationsIds.All(id => metroBranchStationsIds.Contains(id));
       }
   }
}