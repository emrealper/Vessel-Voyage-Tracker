using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VesselPositionTracker.Application.Common.Interfaces;
using VesselPositionTracker.Domain.Common;
using VesselPositionTracker.Persistance.JsonHelpers;

namespace VesselPositionTracker.Persistance.DataHelpers
{
    public class DeserializeJsonLine<E> : IDeserializeJsonLine<E>
          where E : class, IEntity

    {

        private JsonSerializerSettings _settings;


        public DeserializeJsonLine()
        {
            this._settings = new JsonSerializerSettings();
            


        }

        public DeserializeJsonLine(Dictionary<string, string> propertyMapping)
        {
            this._settings = new JsonSerializerSettings();
     
            this._settings.ContractResolver = new JsonAttributeResolver(propertyMapping);

        }


   


    


        public E Serialize(string line)
        {



            return JsonConvert.DeserializeObject<E>(line, this._settings);
        }

        public E Serialize(string line,string dateFormat)
        {


            this._settings.DateFormatString = dateFormat;
            this._settings.Culture = System.Globalization.CultureInfo.InvariantCulture;
            return JsonConvert.DeserializeObject<E>(line, this._settings);
        }




    }
}
