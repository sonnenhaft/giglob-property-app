using System;
using System.Web.Http;
using Client.Api.v1.Facades;
using Client.Api.v1.Models.Models.Common;
using Client.Api.v1.Models.Models.File;
using Client.Api.v1.Models.Models.File.ResponseExamples;
using SwaggerResponseExampleModule;

namespace Client.Api.v1.Controllers
{
    public class FileController : ApiController
    {
        private readonly FileFacade _fileFacade;

        public FileController(FileFacade fileFacade)
        {
            _fileFacade = fileFacade;
        }

        [HttpPost]
        [Authorize]
        [SwaggerResponseExampleProvider(typeof (FileUploadResponseExample))]
        public IHttpActionResult Upload(UploadingFile file)
        {
            var id = _fileFacade.Create(file);
            var result = new FileUploadResultModel
                         {
                             Id = id,
                             Url = Url.Link(
                                 "Default",
                                 new
                                 {
                                     controller = "File",
                                     action = "Get",
                                     id
                                 })
                                      .ToLower()
                         };

            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri(Name = "")] IdentifyModel<Guid> reqModel)
        {
            return _fileFacade.Get(reqModel.Id);
        }
    }
}