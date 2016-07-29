using System.Web;
using System.Web.Hosting;
using Domain.Tools;

namespace Client.Api.Tools.Implementation
{
    public class VirtualPathUtility : IVirtualPathUtility
    {
        public string ConvertToFullPath(string virtualPath)
        {
            var fullPath = virtualPath;

            if (virtualPath.StartsWith("/"))
            {
                virtualPath = string.Format("~{0}", virtualPath);
            }

            if (virtualPath.StartsWith("~"))
            {
                fullPath = HostingEnvironment.MapPath(virtualPath);
                fullPath = FormatPath(fullPath);
            }

            return fullPath;
        }

        private string FormatPath(string path)
        {
            path = path.Replace("/", @"\");
            path = path.Replace(@"\\", @"\");

            return path;
        }
    }
}