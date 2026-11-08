using Amazon.S3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace S3App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class S3FilesController : ControllerBase
    {
        private readonly IAmazonS3 _s3Client;
        public S3FilesController(IAmazonS3 amazonS3)
        {
            _s3Client = amazonS3;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFileAsync(IFormFile file, string bucketName,string? prefix)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file provided.");
            }
            using (var stream = file.OpenReadStream())
            {
                var request = new Amazon.S3.Model.PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = string.IsNullOrEmpty(prefix) ? file.FileName : $"{prefix}/{file.FileName}",
                    InputStream = stream
                };

                request.Metadata.Add("x-amz-meta-title", file.ContentType);
                await _s3Client.PutObjectAsync(request);
            }
            return Ok($"File {file.FileName} uploaded to bucket {bucketName}.");
        }

        [HttpGet("download")]
        public async Task<IActionResult> DownloadFileAsync(string bucketName, string fileName)
        {
            var request = new Amazon.S3.Model.GetObjectRequest
            {
                BucketName = bucketName,
                Key = fileName
            };
            using (var response = await _s3Client.GetObjectAsync(request))
            using (var stream = response.ResponseStream)
            {
                var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                return File(memoryStream, response.Headers.ContentType, fileName);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteFileAsync(string bucketName, string fileName,string? prefix)
        {
            var request = new Amazon.S3.Model.DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = string.IsNullOrEmpty(prefix) ? fileName : $"{prefix}/{fileName}"
            };
            await _s3Client.DeleteObjectAsync(request);
            return Ok($"File {fileName} deleted from bucket {bucketName}.");
        }

        [HttpGet("fileList")]
        public async Task<IActionResult> ListFilesAsync(string bucketName, string? prefix)
        {
            var request = new Amazon.S3.Model.ListObjectsV2Request
            {
                BucketName = bucketName,
                Prefix = prefix
            };
            var response = await _s3Client.ListObjectsV2Async(request);
            var files = response.S3Objects.Select(o => o.Key).ToList();
            return Ok(files);
        }
    }
}
