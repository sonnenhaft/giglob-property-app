using System.Data.Entity;
using Domain.Entities.Implementation.City;
using Domain.Repositories;

namespace Domain.Persistence.EntityFramework.Repositories.Implementation
{
    public class CityRepository : EntityFrameworkRepository<City,long>, ICityRepository
    {
        public CityRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}