using CQRS;
using Domain.Entities.Implementation.User.Services;

namespace Domain.Entities.Implementation.User.Commands
{
    public class User_CreateCommand : ICommand
    {
        public User_CreateCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public long Id { get; set; }
    }

    public class User_CreateCommandHandler : ICommandHandler<User_CreateCommand>
    {
        private readonly IUserAuthorizationService _userAuthorizationService;

        public User_CreateCommandHandler(IUserAuthorizationService userAuthorizationService)
        {
            _userAuthorizationService = userAuthorizationService;
        }

        public void Handle(User_CreateCommand command)
        {
            var user = _userAuthorizationService.Register(command.Email, command.Password);
            command.Id = user.Id;
        }
    }
}