using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using VesselPositionTracker.Application.Common.Interfaces;

namespace VesselPositionTracker.Persistance.Services
{
   public class FileService :IFileService
    {

        private string Destination { get; set; }

        private string Folder { get; set; }

        public FileService(string directory,string folder)
        {

            this.Destination = directory;
            this.Folder = folder;
        }


        public IEnumerable<string> GetJsonFiles()
        {

            return Directory.EnumerateFiles(this.Destination, "*.*", SearchOption.TopDirectoryOnly)
                .Where(s => s.EndsWith(".txt") || s.EndsWith(".json"));
        }

        public IEnumerable<string> ReadLines(string path)
        {

            return File.ReadLines(path,Encoding.UTF8);
        }


    }
}
