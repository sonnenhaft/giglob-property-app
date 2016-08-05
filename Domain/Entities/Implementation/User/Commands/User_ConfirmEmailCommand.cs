using System;
using CQRS;
using Domain.Repositories;

namespace Domain.Entities.Implementation.User.Commands
{
    public class User_ConfirmEmailCommand : ICommand
    {
        public Guid Token { get; set; }

        public User_ConfirmEmailCommand(Guid token)
        {
            Token = token;
        }
    }

    public class User_ConfirmEmailCommandHandler : ICommandHandler<User_ConfirmEmailCommand>
    {
        private readonly IUserRepository _userRepository;

        public User_ConfirmEmailCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Handle(User_ConfirmEmailCommand command)
        {
            var user = _userRepository.GetByEmailConfirmationToken(command.Token);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            user.EmailConfirmationToken = null;
            user.EmailConfirmationTokenExpirationDate = null;
            user.EmailIsConfirmed = true;
        }
    }
}