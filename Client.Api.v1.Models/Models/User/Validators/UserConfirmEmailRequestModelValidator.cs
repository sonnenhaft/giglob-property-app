using Domain.Entities.User.Implementation.Queries;
using FluentValidation;
using SimpleInjector;

namespace Client.Api.v1.Models.Models.User.Validators
{
    public class UserConfirmEmailRequestModelValidator : AbstractValidator<UserConfiirmEmailRequestModel>
    {
        public UserConfirmEmailRequestModelValidator(Container container)
        {
            RuleFor(x => x.Token)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Токен не указан")
                .Must(
                    x => container.GetInstance<User_CheckUserIsExistsByEmailConfirmationTokenQueryHandler>()
                                  .Handle(new User_CheckUserIsExistsByEmailConfirmationTokenQuery(x)))
                .WithMessage("Недействительный токен");
        }
    }
}