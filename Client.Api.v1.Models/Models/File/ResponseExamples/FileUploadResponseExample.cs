using System;
using SwaggerResponseExampleModule.Providers.Interfaces;

namespace Client.Api.v1.Models.Models.File.ResponseExamples
{
    public class FileUploadResponseExample: ISwaggerResponseExampleProvider
    {
        public object GetResponseExample()
        {
            return new FileUploadResultModel
            {
                Id = Guid.NewGuid()
            };
        }
    }
}