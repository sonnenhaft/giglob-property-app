using CQRS;
using Domain.Repositories;

namespace Domain.Entities.Implementation.User.Queries
{
    public class User_GetQuery : IQuery
    {
        public long Id { get; set; }

        public User_GetQuery(long id)
        {
            Id = id;
        }
    }

    public class User_GetQueryHandler : IQueryHandler<User_GetQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public User_GetQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Handle(User_GetQuery query)
        {
            return _userRepository.Get(query.Id);
        }
    }
}