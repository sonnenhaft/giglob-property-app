using System.Linq;
using Domain.Entities.Implementation.City;

namespace Domain.Repositories
{
    public interface ICityRepository : IRepository<City, long>
    {
        IQueryable<District> GetCityDistricts(long cityId);
    }
}