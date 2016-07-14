using CQRS;
using Domain.Entities.User.Services;
using Domain.Repositories;
using Microsoft.AspNet.Identity;

namespace Domain.Entities.Implementation.Commands
{
    public class User_CreateCommand: ICommand
    {
        public User_CreateCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public User User { get; set; }
    }

    public class User_CreateCommandHandler: ICommandHandler<User_CreateCommand>
    {
        private readonly IUserAuthorizationService _userAuthorizationService;

        public User_CreateCommandHandler(IUserAuthorizationService userAuthorizationService)
        {
            _userAuthorizationService = userAuthorizationService;
        }

        public void Handle(User_CreateCommand command)
        {
            var user = _userAuthorizationService.Register(command.Email, command.Password);
            command.User = user;
        }
    }
}