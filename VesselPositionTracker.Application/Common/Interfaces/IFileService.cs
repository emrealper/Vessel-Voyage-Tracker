using System;
using System.Collections.Generic;
using System.Text;

namespace VesselPositionTracker.Application.Common.Interfaces
{
   public interface IFileService
    {


        IEnumerable<string> GetJsonFiles();

        IEnumerable<string> ReadLines(string path);
    }
}
