using System.IO;

namespace Client.Api.v1.Models.Models.File
{
    public class UploadingFile
    {
        public Stream Stream { get; set; }

        public string FileName { get; set; }
    }
}