using System;
using Domain.Entities.Implementation.User;

namespace Domain.Repositories
{
    public interface IUserRepository : IRepository<User, long>
    {
        User Get(string userName);
        User GetByEmailConfirmationToken(Guid token);

        bool IsExists(string userName);
    }
}