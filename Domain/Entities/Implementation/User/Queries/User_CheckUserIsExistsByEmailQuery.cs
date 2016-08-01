using CQRS;
using Domain.Entities.User.Services;
using Domain.Repositories;

namespace Domain.Entities.User.Implementation.Queries
{
    public class User_CheckUserIsExistsByEmailQuery: IQuery
    {
        public string Email { get; set; }

        public User_CheckUserIsExistsByEmailQuery(string email)
        {
            Email = email;
        }
    }

    public class User_CheckUserIsExistsByEmailQueryHandler : IQueryHandler<User_CheckUserIsExistsByEmailQuery, bool>
    {
        private readonly IUserRepository _userRepository;
        public User_CheckUserIsExistsByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Handle(User_CheckUserIsExistsByEmailQuery query)
        {
            return _userRepository.IsExists(query.Email);
        }
    }
}