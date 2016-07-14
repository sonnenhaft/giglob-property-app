using Domain.Entities.Implementation;

namespace Domain.Repositories
{
    public interface IUserRepository: IRepository<User, long>
    {
        User Get(string userName);
    }
}