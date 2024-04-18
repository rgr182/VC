using Amazon.S3;
using Amazon.S3.Model;

namespace VC_API.Domain.Services
{
    public interface IAmazonS3Service
    {
        Task<string> UploadImageAsync(byte[] imageBytes, string fileName);
    }

    public class AmazonS3Service : IAmazonS3Service
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public AmazonS3Service(IAmazonS3 s3Client, string bucketName)
        {
            _s3Client = s3Client;
            _bucketName = bucketName;
        }

        public async Task<string> UploadImageAsync(byte[] imageBytes, string fileName)
        {
            try
            {
                var putObjectRequest = new PutObjectRequest
                {
                    BucketName = _bucketName,
                    Key = $"imagenes/{Guid.NewGuid()}{Path.GetExtension(fileName)}",
                    InputStream = new MemoryStream(imageBytes),
                    ContentType = "image/jpeg"
                };

                var response = await _s3Client.PutObjectAsync(putObjectRequest);

                return response.ETag; // Ahora se utiliza ETag en lugar de Key
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }

            return null;
        }
    }
}
