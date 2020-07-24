using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VesselPositionTracker.Application.Common.Interfaces
{
   public interface IS3Service
    {


        Task<IEnumerable<string>> GetFilesFromBucket(string bucketName);

        IAsyncEnumerable<string> ReadLinesFromLineDelimetedJsonFile(string bucketName, string keyName);
    }
}
