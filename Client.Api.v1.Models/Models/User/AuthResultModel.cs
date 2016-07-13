namespace Client.Api.v1.Models.Models.User
{
    /// <summary>
    /// Модель результата авторизации
    /// </summary>
    public class AuthResultModel
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public UserModel User { get; set; }

        /// <summary>
        /// Bearer-токен
        /// </summary>
        public string AccessToken { get; set; }
    }
}