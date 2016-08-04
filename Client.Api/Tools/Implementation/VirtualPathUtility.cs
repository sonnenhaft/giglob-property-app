using System.Web;
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
                virtualPath = $"~{virtualPath}";
            }

            if (virtualPath.StartsWith("~"))
            {
                virtualPath = virtualPath.Replace("~", "{0}");
                fullPath = string.Format(virtualPath, HttpRuntime.AppDomainAppPath);
                fullPath = FormatPath(fullPath);
            }

            return fullPath;
        }

        private string FormatPath(string path)
        {
            path = path.Replace("/", @"\");

            return path;
        }
    }
}