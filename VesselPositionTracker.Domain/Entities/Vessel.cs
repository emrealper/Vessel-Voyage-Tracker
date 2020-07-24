using System;
using System.Collections.Generic;
using System.Text;
using VesselPositionTracker.Domain.Common;
using VesselPositionTracker.Domain.Enums;

namespace VesselPositionTracker.Domain.Entities
{
   public class Vessel : IEntity
    {

        public Int64 Id { get; set; }

        public int VesselId { get; set; }
        public int Mmmsi { get; set; }

        public VesselType? VesselTypeId { get; set; }
        public int? Imo { get; set; }
        public int FleetId { get; set; }
        public String Name { get; set; }
        public String PlaceOfBuild { get; set; }
        public int? Build { get; set; }
        public float? BreadthExtreme { get; set; }
        public int? SummerDwt { get; set; }
        public int? DisplacementSummer { get; set; }
        public String CallSign { get; set; }
        public String Flag { get; set; }
        public float? Draught { get; set; }
        public float? LengthOverall { get; set; }
        public String FuelConsumption { get; set; }
        public float? SpeedMax { get; set; }
        public float? SpeedService { get; set; }
        public int? LiquidOil { get; set; }
        public String Owner { get; set; }
        public String Manager { get; set; }
    
        public String ManagerOwner { get; set; }
        public int Active { get; set; }
    }
}
