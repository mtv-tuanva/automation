using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace WebTest.Specs.Helpers
{
    public abstract class FileStorageService
    {
        protected readonly BlobContainerClient ContainerClient;

        protected virtual string Container => "evidences";

        public FileStorageService(IConfiguration configuration)
        {
            ContainerClient = new BlobContainerClient(configuration.GetConnectionString("FileStorage"), Container);
        }

        public string UploadFile(string filePath)
        {
            return filePath;

            var uploadFileName = filePath.Replace($"{Directory.GetCurrentDirectory()}\\", "").Replace('\\', '/');// $"{DateTime.UtcNow:yyyyMMdd}/{Path.GetFileName(filePath)}";
            var blobClient = ContainerClient.GetBlobClient(uploadFileName);

            //blobClient.Upload(filePath, true);

            return $"{ContainerClient.Uri.AbsoluteUri.Trim('/')}/{uploadFileName}";
        }
    }

    public class VideoStorageService : FileStorageService
    {
        public VideoStorageService(IConfiguration configuration) : base(configuration)
        {
        }

    }

    public class ScreenshotStorageService : FileStorageService
    {
        public ScreenshotStorageService(IConfiguration configuration) : base(configuration)
        {
        }

    }
}
