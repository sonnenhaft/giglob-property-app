using System.Net;
using Client.Api.v1.Models.Models.User;
using Domain.Entities.Implementation;
using Domain.Entities.Implementation.Commands;
using Domain.Entities.User.Services;
using ExpressMapper.Extensions;

namespace Client.Api.v1.Facades
{
    public class UserFacade
    {
        private readonly User_CreateCommandHandler _userCreateCommandHandler;
        private readonly IUserAuthorizationService _userAuthorizationService;

        public UserFacade(User_CreateCommandHandler userCreateCommandHandler, IUserAuthorizationService userAuthorizationService)
        {
            _userCreateCommandHandler = userCreateCommandHandler;
            _userAuthorizationService = userAuthorizationService;
        }

        public AuthResultModel RegisterUser(UserRegisterRequestModel requestModel)
        {
            var command = new User_CreateCommand(requestModel.Email, requestModel.Password);
            _userCreateCommandHandler.Handle(command);

            return new AuthResultModel
            {
                AccessToken = _userAuthorizationService.GenerateAccessToken(requestModel.Email, requestModel.Password)
            };
        }
    }
}