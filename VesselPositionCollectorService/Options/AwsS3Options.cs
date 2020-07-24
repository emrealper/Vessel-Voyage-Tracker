using System;
using System.Collections.Generic;
using System.Text;

namespace VesselPositionCollectorService.Options
{
   public class AwsS3Options
    {

        public Uri ServiceUrl { get; set; }
        public string AccessKey { get; set; }

        public string SecretAccessKey { get; set; }

        public void Deconstruct(out Uri serviceUrl, out string accessKey,
           out string secretAccessKey)
        {
            serviceUrl = ServiceUrl;
            accessKey = AccessKey;
            secretAccessKey = SecretAccessKey;
        }
    }
}
