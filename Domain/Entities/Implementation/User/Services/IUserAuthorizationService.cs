namespace Domain.Entities.Implementation.User.Services
{
    public interface IUserAuthorizationService
    {
        User Register(string email, string password);

        string GenerateAccessToken(string userName, string password);

        bool Check(string userName, string password);
    }
}