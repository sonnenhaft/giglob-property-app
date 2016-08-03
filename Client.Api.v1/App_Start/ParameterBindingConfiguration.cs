using System.Web.Http.ModelBinding;
using Client.Api.v1.HttpParameterBinding;
using Client.Api.v1.Models.Models.File;

namespace Client.Api.v1
{
    public class ParameterBindingConfiguration
    {
        public static void Configure(ParameterBindingRulesCollection rules)
        {
            rules.Add(
                descriptor =>
                {
                    if (descriptor.ParameterType == typeof (UploadingFile))
                    {
                        return new MultipartFilesParameterBinding(descriptor);
                    }

                    return null;
                });
        }
    }
}