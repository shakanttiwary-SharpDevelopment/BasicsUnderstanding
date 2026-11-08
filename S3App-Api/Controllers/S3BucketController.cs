using Amazon.S3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace S3App_Api.Controllers
{
    /// <summary>
    /// S3BucketController provides endpoints to manage S3 buckets, including creating, listing, and deleting buckets.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class S3BucketController : ControllerBase
    {
        // The S3 client used to interact with Amazon S3 services.
        public readonly IAmazonS3 _s3Client;

        /// <summary>
        /// Initializes a new instance of the <see cref="S3BucketController"/> class.
        /// </summary>
        /// <param name="s3Client"></param>
        public S3BucketController(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        /// <summary>
        /// Creates a new S3 bucket.
        /// </summary>
        /// <param name="bucketName"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBucketAsync(string bucketName)
        {
           var bucketExists = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, bucketName);
            if(bucketExists) return BadRequest($"Bucket with name {bucketName} already exists.");

            await _s3Client.PutBucketAsync(bucketName);
            return Created("bucket",$"Bucket created: {bucketName}");
        }

        /// <summary>
        /// Lists all S3 buckets.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ListBucketsAsync()
        {
            var response = await _s3Client.ListBucketsAsync();
            var bucketsResult = response.Buckets.Select(b => b.BucketName).ToList();
            return Ok(bucketsResult);
        }

        /// <summary>
        /// Deletes an existing S3 bucket.
        /// </summary>
        /// <param name="bucketName"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteBucketAsync(string bucketName)
        {
            var bucketExists = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, bucketName);
            if (!bucketExists) return BadRequest($"Bucket with name {bucketName} does not exist.");

            await _s3Client.DeleteBucketAsync(bucketName);
            return Ok($"Bucket deleted: {bucketName}");
        }
    }
}
