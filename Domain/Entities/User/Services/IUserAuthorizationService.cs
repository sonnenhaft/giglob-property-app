namespace Domain.Entities.User.Services
{
    public interface IUserAuthorizationService
    {
        Implementation.User Register(string email, string password);

        string GenerateAccessToken(string userName, string password);
    }
}