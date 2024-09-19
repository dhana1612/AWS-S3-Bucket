using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.Runtime;
using Amazon.S3.Model;

class S3Uploader
{
    static void Main(string[] args)
    {
        //AWS_Buckets
        string sourceBucketName = "samplefileupload2024";
        string destinationBucketName = "sharedfile2024";

        string keyName = "1612";
        string filePath = @"C:\Users\Morning Shift\Desktop\Images\cake.jpeg";

        // Set up your AWS credentials
        string accessKey = /*Access Key */ ;
        string secretAccessKey = /* SecretAccessKey  */;

        // Create a new Amazon S3 client
        AmazonS3Client s3Client = new AmazonS3Client(accessKey, secretAccessKey, Amazon.RegionEndpoint.EUNorth1);

        try
        {
            // Upload the file to the source bucket
            TransferUtility ft = new TransferUtility(s3Client);
            ft.Upload(filePath, sourceBucketName, keyName);
            Console.WriteLine("Upload completed!");

            // Copy the object to the destination bucket
            CopyObjectRequest c = new CopyObjectRequest
            {
                SourceBucket = sourceBucketName,
                SourceKey = keyName,
                DestinationBucket = destinationBucketName,
                DestinationKey = keyName
            };

            CopyObjectResponse cr = s3Client.CopyObjectAsync(c).Result;
            Console.WriteLine("Copy completed!");

            

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error encountered: {e.Message}");
        }


        //DeleteClass dp = new DeleteClass();
        //dp.delete(accesskey, secertAccessKey, bucketName1);


    }
}