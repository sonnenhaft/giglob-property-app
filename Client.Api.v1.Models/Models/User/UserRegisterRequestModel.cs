namespace Client.Api.v1.Models.Models.User
{
    /// <summary>
    /// Модель регистрации пользователя
    /// </summary>
    public class UserRegisterRequestModel
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