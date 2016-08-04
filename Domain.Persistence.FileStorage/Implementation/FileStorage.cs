using System.IO;
using Domain.Storages;
using Domain.Tools;

namespace Domain.Persistence.FileStorage.Implementation
{
    public class FileStorage : IFileStorage
    {
        private readonly IVirtualPathUtility _virtualPathUtility;

        public FileStorage(IVirtualPathUtility virtualPathUtility)
        {
            _virtualPathUtility = virtualPathUtility;
        }

        public void Create(Stream stream, string virtualPath, FileMode mode)
        {
            var fullPath = _virtualPathUtility.ConvertToFullPath(virtualPath);
            CreateDirectoryIfNotExists(fullPath);

            using (var fs = new FileStream(fullPath, mode))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fs);
            }
        }

        public Stream Get(string virtualPath)
        {
            var fullPath = _virtualPathUtility.ConvertToFullPath(virtualPath);
            var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read);

            return fs;
        }

        private void CreateDirectoryIfNotExists(string path)
        {
            var directory = Path.GetDirectoryName(path);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}