using Domain.Entities.Implementation;
using Domain.Entities.Implementation.City;

namespace Domain.Repositories
{
    public interface ICityRepository: IRepository<City, long> { }
}