using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using Client.Api.v1.Models.Models.File;
using Client.Api.v1.MultipartMemoryStreamProviders;

namespace Client.Api.v1.HttpParameterBinding
{
    public class MultipartFilesParameterBinding : System.Web.Http.Controllers.HttpParameterBinding
    {
        public MultipartFilesParameterBinding(HttpParameterDescriptor descriptor) : base(descriptor) { }

        public override async Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var provider = new ExtendedMultipartMemoryStreamProvider();
            var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMinutes(2));

            await actionContext.Request.Content.ReadAsMultipartAsync(provider, cancellationTokenSource.Token);

            if (cancellationTokenSource.IsCancellationRequested)
            {
                throw new TimeoutException("File uploades too long");
            }

            var fileStreamContent = provider.GetValues("File")
                                            .FirstOrDefault();
            var fileNameContent = provider.GetValues("FileName")
                                          .FirstOrDefault();
            var fileStream = fileStreamContent != null ? await fileStreamContent.ReadAsStreamAsync() : null;
            var fileName = fileNameContent != null ? await fileNameContent.ReadAsStringAsync() : null;

            actionContext.ActionArguments[Descriptor.ParameterName] = new UploadingFile
                                                                      {
                                                                          Stream = fileStream,
                                                                          FileName = fileName
                                                                      };
        }
    }
}