using System;
using CQRS;
using Domain.Repositories;

namespace Domain.Entities.Implementation.User.Commands
{
    public class User_GenerateEmailConfirmationTokenCommand : ICommand
    {
        public long UserId { get; set; }

        public User_GenerateEmailConfirmationTokenCommand(long userId)
        {
            UserId = userId;
        }
    }

    public class User_GenerateEmailConfirmationTokenCommandHandler : ICommandHandler<User_GenerateEmailConfirmationTokenCommand>
    {
        private readonly IUserRepository _userRepository;

        public User_GenerateEmailConfirmationTokenCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Handle(User_GenerateEmailConfirmationTokenCommand command)
        {
            var user = _userRepository.Get(command.UserId);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            user.EmailConfirmationToken = Guid.NewGuid();
            user.EmailConfirmationTokenExpirationDate = DateTime.UtcNow.AddDays(1);
        }
    }
}