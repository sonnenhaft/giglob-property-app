using SwaggerResponseExampleModule.Providers.Interfaces;

namespace Client.Api.v1.Models.Models.User.ResponseExamples
{
    public class AuthResultModelResponseExample : ISwaggerResponseExampleProvider
    {
        public object GetResponseExample()
        {
            return new AuthResultModel
                   {
                       AccessToken = "There must be a bearer token, but there is not."
                   };
        }
    }
}