using System.Text.RegularExpressions;
using Client.Api.v1.Models.Constants;
using Domain.Entities.Implementation.User.Queries;
using FluentValidation;
using SimpleInjector;

namespace Client.Api.v1.Models.Models.User.Validators
{
    public class UserRegisterRequestModelValidator : AbstractValidator<UserRegisterRequestModel>
    {
        public UserRegisterRequestModelValidator(Container container)
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Введите адрес электронной почты")
                .Must(x => Regex.IsMatch(x, RegexConstants.EmailRegex))
                .WithMessage("Некорректный адрес электронной почты")
                .Must(x => x.Length <= 64)
                .WithMessage("Максимальная длина - 64 символа")
                .Must(
                    x => !container.GetInstance<User_CheckUserIsExistsByEmailQueryHandler>()
                                   .Handle(new User_CheckUserIsExistsByEmailQuery(x)))
                .WithMessage("Введенная почта уже зарегистрирована в системе");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Введите пароль")
                .Length(6, 130)
                .WithMessage("Минимум 6, максимум 130 символов");
        }
    }
}