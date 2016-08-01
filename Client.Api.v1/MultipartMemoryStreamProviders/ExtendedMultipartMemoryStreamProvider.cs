using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Api.v1.MultipartMemoryStreamProviders
{
    public class ExtendedMultipartMemoryStreamProvider: MultipartMemoryStreamProvider
    {
        public IEnumerable<HttpContent> GetValues(string key)
        {
            return Contents.Where(x => x.Headers.ContentDisposition.Name.Replace("\"", "") == key);
        }
    }
}