using System;
using CQRS;
using Domain.Repositories;

namespace Domain.Entities.User.Implementation.Queries
{
    public class User_CheckUserIsExistsByEmailConfirmationTokenQuery : IQuery
    {
        public Guid Token { get; set; }

        public User_CheckUserIsExistsByEmailConfirmationTokenQuery(Guid token)
        {
            Token = token;
        }
    }

    public class User_CheckUserIsExistsByEmailConfirmationTokenQueryHandler : IQueryHandler<User_CheckUserIsExistsByEmailConfirmationTokenQuery, bool>
    {
        private readonly IUserRepository _userRepository;

        public User_CheckUserIsExistsByEmailConfirmationTokenQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Handle(User_CheckUserIsExistsByEmailConfirmationTokenQuery query)
        {
            return _userRepository.GetByEmailConfirmationToken(query.Token) != null;
        }
    }
}