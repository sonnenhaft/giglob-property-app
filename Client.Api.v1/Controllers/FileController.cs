using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Client.Api.v1.Models.Models.Common;
using Client.Api.v1.Models.Models.Common.ResponseExamples;
using Client.Api.v1.Models.Models.File;
using Client.Api.v1.Models.Models.File.ResponseExamples;
using Client.Api.v1.Results;
using SwaggerResponseExampleModule;

namespace Client.Api.v1.Controllers
{
    public class FileController : ApiController
    {
        [HttpPost]
        [SwaggerResponseExampleProvider(typeof(FileUploadResponseExample))]
        public IHttpActionResult Upload()
        {
            return Ok(new FileUploadResponseExample().GetResponseExample());
        }

        [HttpPost]
        [SwaggerResponseExampleProvider(typeof(SuccessResponseExample))]
        public IHttpActionResult Remove(IdentifyModel<Guid> reqModel)
        {
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri(Name = "")] IdentifyModel<Guid> reqModel)
        {
            return new FileResult(reqModel.Id.ToString());
        }
    }   
}