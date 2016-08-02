using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Client.Api
{
    public class JsonFormatterConfiguration
    {
        public static void Configure(JsonMediaTypeFormatter formatter)
        {
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}