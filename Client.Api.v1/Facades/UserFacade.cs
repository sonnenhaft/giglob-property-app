﻿using System;
using System.Configuration;
using Client.Api.v1.Models.Models.User;
using Client.Api.v1.Models.Models.User.Mail;
using CQRS;
using Domain.Entities.Implementation.User;
using Domain.Entities.Implementation.User.Commands;
using Domain.Entities.Implementation.User.Queries;
using Domain.Entities.Implementation.User.Services;
using FluentMailer.Interfaces;

namespace Client.Api.v1.Facades
{
    public class UserFacade
    {
        private readonly IUserAuthorizationService _userAuthorizationService;
        private readonly IFluentMailer _fluentMailer;

        private readonly ICommandHandler<User_CreateCommand> _userCreateCommandHandler;
        private readonly ICommandHandler<User_GenerateEmailConfirmationTokenCommand> _userGenerateEmailConfirmationTokenCommandHandler;
        private readonly ICommandHandler<User_ConfirmEmailCommand> _userConfirmEmailCommandHandler;

        private readonly IQueryHandler<User_GetQuery, User> _userGetQueryHandler;

        public UserFacade(
            IUserAuthorizationService userAuthorizationService,
            IFluentMailer fluentMailer,
            ICommandHandler<User_CreateCommand> userCreateCommandHandler,
            ICommandHandler<User_GenerateEmailConfirmationTokenCommand> userGenerateEmailConfirmationTokenCommandHandler,
            ICommandHandler<User_ConfirmEmailCommand> userConfirmEmailCommandHandler,
            IQueryHandler<User_GetQuery, User> userGetQueryHandler)
        {
            _userAuthorizationService = userAuthorizationService;
            _fluentMailer = fluentMailer;
            _userCreateCommandHandler = userCreateCommandHandler;
            _userGenerateEmailConfirmationTokenCommandHandler = userGenerateEmailConfirmationTokenCommandHandler;
            _userConfirmEmailCommandHandler = userConfirmEmailCommandHandler;
            _userGetQueryHandler = userGetQueryHandler;
        }

        public AuthResultModel RegisterUser(UserRegisterRequestModel requestModel)
        {
            var command = new User_CreateCommand(requestModel.Email, requestModel.Password);
            _userCreateCommandHandler.Handle(command);
            var user = _userGetQueryHandler.Handle(new User_GetQuery(command.Id));
            _userGenerateEmailConfirmationTokenCommandHandler.Handle(new User_GenerateEmailConfirmationTokenCommand(user.Id));
            _fluentMailer.CreateMessage()
                         .WithView(
                             "~/Views/User/Mail/UserConfirmationMail.cshtml",
                             new UserConfirmationMailModel
                             {
                                 Url = ConfigurationManager.AppSettings["WebUrl"] + "/#/user/confirmemail/" + user.EmailConfirmationToken
                             })
                         .WithReceiver(user.Email)
                         .Send();

            return SignIn(requestModel.Email, requestModel.Password);
        }

        public AuthResultModel SignIn(UserSignInRequestModel requestModel)
        {
            return SignIn(requestModel.Email, requestModel.Password);
        }

        public void ConfirmEmail(Guid token)
        {
            _userConfirmEmailCommandHandler.Handle(new User_ConfirmEmailCommand(token));
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