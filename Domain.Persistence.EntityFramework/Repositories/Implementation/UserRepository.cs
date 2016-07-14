using System.Data.Entity;
using System.Linq;
using Domain.Entities.Implementation;
using Domain.Repositories;

namespace Domain.Persistence.EntityFramework.Repositories.Implementation
{
    public class UserRepository: EntityFrameworkRepository<User, long>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }

        public User Get(string userName)
        {
            return GetAll()
                .FirstOrDefault(x => x.UserName == userName);
        }
    }
}