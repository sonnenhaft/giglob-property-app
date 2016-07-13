using System.Net;
using System.Web.Http;
using Client.Api.v1.Models.Models.Common.ResponseExamples;
using Client.Api.v1.Models.Models.User;
using Client.Api.v1.Models.Models.User.ResponseExamples;
using SwaggerResponseExampleModule;

namespace Client.Api.v1.Controllers
{
    public class UserController: ApiController
    {
        [HttpPost]
        [SwaggerResponseExampleProvider(typeof(AuthResultModelResponseExample))]
        [SwaggerResponseExampleProvider(HttpStatusCode.BadRequest, typeof(BadRequestResponseExampleProvider))]
        public IHttpActionResult Register(UserRegisterRequestModel reqModel)
        {
            return Ok(new AuthResultModel
            {
                AccessToken = "There must be a bearer token, but there is not.",
                User = new UserModel
                {
                    Id = 1,
                    Email = "abc@abc.abc"
                }
            });
        }

        [HttpPost]
        [SwaggerResponseExampleProvider(typeof(AuthResultModelResponseExample))]
        [SwaggerResponseExampleProvider(HttpStatusCode.BadRequest, typeof(BadRequestResponseExampleProvider))]
        public IHttpActionResult SignIn(UserSignInRequestModel reqModel)
        {
            return Ok(new AuthResultModel
            {
                AccessToken = "There must be a bearer token, but there is not.",
                User = new UserModel
                {
                    Id = 1,
                    Email = "abc@abc.abc"
                }
            });
        }
    }
}