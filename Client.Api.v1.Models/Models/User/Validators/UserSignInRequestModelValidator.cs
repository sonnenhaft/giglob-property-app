using System.Text.RegularExpressions;
using Client.Api.v1.Models.Constants;
using Domain.Entities.User.Implementation.Queries;
using FluentValidation;
using FluentValidation.Results;
using SimpleInjector;

namespace Client.Api.v1.Models.Models.User.Validators
{
    public class UserSignInRequestModelValidator : AbstractValidator<UserSignInRequestModel>
    {
        public UserSignInRequestModelValidator(Container container)
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Введите адрес электронной почты")
                .Must(x => Regex.IsMatch(x, RegexConstants.EmailRegex))
                .WithMessage("Некорректный адрес электронной почты")
                .Must(x => x.Length <= 64)
                .WithMessage("Максимальная длина - 64 символа");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Введите пароль");

            Custom(x => CheckUserIsExists(container.GetInstance<User_CheckUserIsExistsByUsernameAndPasswordQueryHandler>(), x.Email, x.Password));
        }

        private ValidationFailure CheckUserIsExists(User_CheckUserIsExistsByUsernameAndPasswordQueryHandler userCheckUserIsExistsByUsernameAndPasswordQueryHandler, string email, string password)
        {
            if (!userCheckUserIsExistsByUsernameAndPasswordQueryHandler.Handle(new User_CheckUserIsExistsByUsernameAndPasswordQuery(email, password)))
            {
                return new ValidationFailure("Password", "Почта или пароль указаны неверно");
            }

            return null;
        }
    }
}