using System;
using System.Collections.Generic;
using System.Text;

namespace VesselPositionTracker.Domain.Common
{
   public interface ICosmosEntity
    {

         String Id { get; set; }

        int ShipId { get; set; }
    }
}
