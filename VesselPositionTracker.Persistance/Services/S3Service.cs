using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesselPositionTracker.Application.Common.Interfaces;

namespace VesselPositionTracker.Persistance.Services
{
   public class S3Service :IS3Service

    {


        private static IAmazonS3 client;

        public S3Service(string accessKeyId, string secretAccessKey, string serviceUrl)
        {
            Amazon.S3.AmazonS3Config s3Config = new Amazon.S3.AmazonS3Config();
            s3Config.ServiceURL = serviceUrl;
            client = new Amazon.S3.AmazonS3Client(accessKeyId, secretAccessKey, s3Config);
        }


        public async Task<IEnumerable<string>> GetFilesFromBucket(string bucketName)
        {

            try
            {




                ListObjectsV2Request request = new ListObjectsV2Request
                {
                    BucketName = bucketName,
                  
                };
                ListObjectsV2Response response;
                response = await client.ListObjectsV2Async(request);

                IEnumerable<string> fileList = from file in response.S3Objects
                                               select file.Key;

                return fileList;
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                //Console.WriteLine("S3 error occurred. Exception: " + amazonS3Exception.ToString());
                //Console.ReadKey();
                return null;
            }
            catch (Exception e)
            {
                //Console.WriteLine("Exception: " + e.ToString());
                //Console.ReadKey();
                return null;
            }


        }

        public async IAsyncEnumerable<string> ReadLinesFromLineDelimetedJsonFile(string bucketName,string keyName)
        {

            string line = string.Empty;

            GetObjectRequest request = new GetObjectRequest
            {
                BucketName = bucketName,
                Key=keyName
               
            };
            using (var response = await client.GetObjectAsync(request))
            using (Stream responseStream = response.ResponseStream)
            using (StreamReader reader = new StreamReader(responseStream))
            {

               

                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                  
                }

                reader.Close();
            }






        }

    }
}
