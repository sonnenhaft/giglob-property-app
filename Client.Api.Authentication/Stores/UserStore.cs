using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Implementation;
using Domain.Repositories;
using Microsoft.AspNet.Identity;

namespace Client.Api.Authentication.Stores
{
    public class UserStore: IUserStore<User, long>, IUserPasswordStore<User, long>
    {
        private readonly IUserRepository _userRepository;

        public UserStore(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Dispose() { }

        public Task CreateAsync(User user)
        {
            return Task.Run(() =>
            {
                _userRepository.Add(user);
                _userRepository.SaveChanges();
            });
        }

        public Task UpdateAsync(User user)
        {
            return Task.Run(() =>
            {
                _userRepository.SaveChanges();
            });
        }

        public Task DeleteAsync(User user)
        {
            return Task.Run(() =>
            {
                _userRepository.Remove(user);
                _userRepository.SaveChanges();
            });
        }

        public Task<User> FindByIdAsync(long userId)
        {
            return Task.Run(() => _userRepository.Get(userId));
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return Task.Run(() => _userRepository.Get(userName));
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            return Task.Run(() =>
            {
                user.PasswordHash = passwordHash;
                _userRepository.SaveChanges();
            });
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.Run(() => user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.Run(() => user.PasswordHash != null && user.PasswordHash.Any());
        }
    }
}