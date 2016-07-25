using System.IO;

namespace Domain.Storages
{
    public interface IFileStorage
    {
        void Create(Stream stream, string virtualPath, FileMode mode);

        Stream Get(string virtualPath);
    }
}