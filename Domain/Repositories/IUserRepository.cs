using Domain.Entities.User.Implementation;

namespace Domain.Repositories
{
    public interface IUserRepository: IRepository<User, long>
    {
        User Get(string userName);

        bool IsExists(string userName);
    }
}