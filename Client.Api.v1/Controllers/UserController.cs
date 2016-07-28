using System.Net;
using System.Web.Http;
using Client.Api.v1.Facades;
using Client.Api.v1.Models.Models.Common.ResponseExamples;
using Client.Api.v1.Models.Models.User;
using Client.Api.v1.Models.Models.User.ResponseExamples;
using SwaggerResponseExampleModule;

namespace Client.Api.v1.Controllers
{
    public class UserController: ApiController
    {
        private readonly UserFacade _userFacade;

        public UserController(UserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpPost]
        [SwaggerResponseExampleProvider(typeof(AuthResultModelResponseExample))]
        [SwaggerResponseExampleProvider(HttpStatusCode.BadRequest, typeof(BadRequestResponseExampleProvider))]
        public IHttpActionResult Register(UserRegisterRequestModel reqModel)
        {
            return Ok(_userFacade.RegisterUser(reqModel));
        }

        [HttpPost]
        [SwaggerResponseExampleProvider(typeof(AuthResultModelResponseExample))]
        [SwaggerResponseExampleProvider(HttpStatusCode.BadRequest, typeof(BadRequestResponseExampleProvider))]
        public IHttpActionResult SignIn(UserSignInRequestModel reqModel)
        {
            return Ok(_userFacade.SignIn(reqModel));
        }

        [HttpPost]
        [SwaggerResponseExampleProvider(typeof(SuccessResponseExample))]
        public IHttpActionResult ConfirmEmail(UserConfiirmEmailRequestModel reqModel)
        {
            _userFacade.ConfirmEmail(reqModel.Token);

            return Ok();
        }
    }
}