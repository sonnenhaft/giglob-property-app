using System;
using System.Data.Entity;
using System.Linq;
using Domain.Entities.Implementation.City;
using Domain.Repositories;

namespace Domain.Persistence.EntityFramework.Repositories.Implementation
{
    public class CityRepository : EntityFrameworkRepository<City, long>, ICityRepository
    {
        public CityRepository(DbContext dbContext) : base(dbContext) { }

        public IQueryable<District> GetCityDistricts(long cityId)
        {
            if (!IsExists(cityId))
            {
                throw new ArgumentException("City not found");
            }

            return GetAll()
                .Where(x => x.Id == cityId)
                .SelectMany(x => x.Districts);
        }
    }
}