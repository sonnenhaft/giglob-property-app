namespace Client.Api.v1.Models.Models.User
{
    /// <summary>
    ///     Модель результата авторизации
    /// </summary>
    public class AuthResultModel
    {
        /// <summary>
        ///     Bearer-токен
        /// </summary>
        public string AccessToken { get; set; }
    }
}