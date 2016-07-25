using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Domain.Entities.Implementation.File;

namespace Client.Api.v1.Results
{
    public class FileResult: IHttpActionResult
    {
        private readonly File _file;

        public FileResult(File file)
        {
            _file = file;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(_file.Stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = _file.Name
            };

            return Task.FromResult(result);
        }
    }
}