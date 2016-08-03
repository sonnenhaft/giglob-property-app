using System;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using Domain.Entities.User.Implementation;
using Domain.Repositories;

namespace Domain.Persistence.EntityFramework.Repositories.Implementation
{
    public class UserRepository : EntityFrameworkRepository<User, long>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }

        public User Get(string userName)
        {
            userName = PrepareEmail(userName);

            return GetAll()
                .FirstOrDefault(x => x.UserName == userName);
        }

        public User GetByEmailConfirmationToken(Guid token)
        {
            return GetAll()
                .FirstOrDefault(x => x.EmailConfirmationToken == token && x.EmailConfirmationTokenExpirationDate > DateTime.UtcNow);
        }

        public bool IsExists(string userName)
        {
            userName = PrepareEmail(userName);

            return GetAll()
                .Any(x => x.UserName == userName);
        }

        private string PrepareEmail(string email)
        {
            return Regex.Replace(email, @"^([^@]+)", x => x.Groups[1].Value.Replace(".", ""))
                        .ToLower();
        }
    }
}