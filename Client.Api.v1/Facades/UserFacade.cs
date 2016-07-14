using System.Net;
using Client.Api.v1.Models.Models.User;
using Domain.Entities.User.Implementation.Commands;
using Domain.Entities.User.Implementation.Queries;
using Domain.Entities.User.Services;
using ExpressMapper.Extensions;

namespace Client.Api.v1.Facades
{
    public class UserFacade
    {
        private readonly IUserAuthorizationService _userAuthorizationService;

        private readonly User_CreateCommandHandler _userCreateCommandHandler;

        public UserFacade(IUserAuthorizationService userAuthorizationService, User_CreateCommandHandler userCreateCommandHandler)
        {
            _userCreateCommandHandler = userCreateCommandHandler;
            _userAuthorizationService = userAuthorizationService;
        }

        public AuthResultModel RegisterUser(UserRegisterRequestModel requestModel)
        {
            var command = new User_CreateCommand(requestModel.Email, requestModel.Password);
            _userCreateCommandHandler.Handle(command);

            return SignIn(requestModel.Email, requestModel.Password);
        }

        public AuthResultModel SignIn(UserSignInRequestModel requestModel)
        {
            return SignIn(requestModel.Email, requestModel.Password);
        }

        private AuthResultModel SignIn(string email, string password)
        {
            return new AuthResultModel
            {
                AccessToken = _userAuthorizationService.GenerateAccessToken(email, password)
            };
        }
    }
}