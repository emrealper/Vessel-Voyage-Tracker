using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesselPositionTracker.Application.Common.Interfaces;
using VesselPositionTracker.Domain.Entities;
using VesselPositionTracker.Persistance.DataHelpers;
using VesselPositionTracker.Persistance.Services;

namespace OneOffManipuLATions
{
    class Program
    {


       private static FileService fileService = new FileService(@"D:\Projects\VesselPositionTracker\VesselPositionTracker.Persistance\Voyage-Data-On-AWS-S3", "");
      





        static void Main(string[] args)
        {

          


            Parallel.ForEach(fileService.GetJsonFiles(), (path) =>
            {
                FixDateInJsonFile(path);
                
            });

          




            Console.ReadLine();

        }


        private static string NewLine => "\r\n";

        private static async Task FixDateInJsonFile(string path)
        {

            Dictionary<string, string> _attributeMappings = new Dictionary<string, string>
        {

{"Mmmsi","MMSI"},
{"Status","STATUS"},
{"Speed","SPEED"},
{"Lon","LON"},
{"LAT","LAT"},
{"COURSE","COURSE"},
{"HEADING","HEADING"},
{"TIMESTAMP","TIMESTAMP"},
{"SHIP_ID","SHIP_ID"},
{"WIND_ANGLE","WIND_ANGLE"},
{"WindSpeed","WIND_SPEED"},
{"WindTemp","WIND_TEMP"}



 };

            DeserializeJsonLine<VesselHistory> _deserializeJsonLine = new DeserializeJsonLine<VesselHistory>(_attributeMappings);

            int count = 0;


  

            foreach (string line in fileService.ReadLines(path))
            {
                StringBuilder jsonResult = new StringBuilder();
                VesselHistory entity=  _deserializeJsonLine.Serialize(line);
                entity.TimeStamp = entity.TimeStamp.Value.AddSeconds(++count);

                

                jsonResult.Append(JsonConvert.SerializeObject(entity).Replace("\"Id\":null,", ""));
                jsonResult.Append(NewLine);

                System.IO.File.AppendAllText(path.Replace(".json", "_new") + ".json", jsonResult.ToString());
            }
     

        }


    }
}
