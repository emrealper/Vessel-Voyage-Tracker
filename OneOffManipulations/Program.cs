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

            //foreach (string path in fileService.GetJsonFiles())
            //{

            //    FixDateInJsonFile(path);
            //}

         






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
{"Course","COURSE"},
{"Heading","HEADING"},
{"TimeStamp","TIMESTAMP"},
{"ShipId","SHIP_ID"},
{"WindAngle","WIND_ANGLE"},
{"WindSpeed","WIND_SPEED"},
{"WindTemp","WIND_TEMP"}



 };

            DeserializeJsonLine<VesselHistory> _deserializeJsonLine = new DeserializeJsonLine<VesselHistory>(_attributeMappings);

            int count = 0;

            int mmsi = 0;

            StringBuilder jsonResult = new StringBuilder();
            foreach (string line in fileService.ReadLines(path))
            {

          
                VesselHistory entity=  _deserializeJsonLine.Serialize(line);
                
                entity.TimeStamp = entity.TimeStamp.Value.AddSeconds(++count);

                if (mmsi == 0)
                {
                    mmsi = entity.Mmmsi +100;

                }

                entity.Mmmsi += 100;
                entity.ShipId += 100;
                jsonResult.Append(JsonConvert.SerializeObject(entity).Replace("\"Id\":null,", "").
                    Replace("Mmmsi", "MMSI").Replace("Status", "STATUS").Replace("Speed","SPEED")
                    .Replace("Lon","LON").Replace("Course","COURSE").Replace("Heading","HEADING")
                    .Replace("TimeStamp","TIMESTAMP").Replace("ShipId","SHIP_ID").Replace("WindAngle","WIND_ANGLE")
                    .Replace("WindSpeed","WIND_SPEED").Replace("WindTemp","WIND_TEMP"));
                jsonResult.Append(NewLine);
                
               
            }
            System.IO.File.AppendAllText(@"D:\Projects\VesselPositionTracker\VesselPositionTracker.Persistance\Voyage-Data-On-AWS-S3\Vessel_" + mmsi.ToString() + "_Movements.json", jsonResult.ToString());


        }


    }
}
