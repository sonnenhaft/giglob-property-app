using CQRS;
using Domain.Entities.Implementation.User.Services;

namespace Domain.Entities.Implementation.User.Queries
{
    public class User_CheckUserIsExistsByUsernameAndPasswordQuery : IQuery
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public User_CheckUserIsExistsByUsernameAndPasswordQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }

    public class User_CheckUserIsExistsByUsernameAndPasswordQueryHandler : IQueryHandler<User_CheckUserIsExistsByUsernameAndPasswordQuery, bool>
    {
        private readonly IUserAuthorizationService _userAuthorizationService;

        public User_CheckUserIsExistsByUsernameAndPasswordQueryHandler(IUserAuthorizationService userAuthorizationService)
        {
            _userAuthorizationService = userAuthorizationService;
        }

        public bool Handle(User_CheckUserIsExistsByUsernameAndPasswordQuery query)
        {
            return _userAuthorizationService.Check(query.UserName, query.Password);
        }
    }
}