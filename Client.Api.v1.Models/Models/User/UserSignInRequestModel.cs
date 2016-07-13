namespace Client.Api.v1.Models.Models.User
{
    /// <summary>
    /// Модель авторизации пользователя
    /// </summary>
    public class UserSignInRequestModel
    {
        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
    }
}