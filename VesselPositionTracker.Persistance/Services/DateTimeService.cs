using System;
using System.Collections.Generic;
using System.Text;
using VesselPositionTracker.Application.Common.Interfaces;

namespace VesselPositionTracker.Persistance.Services
{
   public class DateTimeService :IDateTime
    {

        public DateTime Now => DateTime.Now;
    }
}
