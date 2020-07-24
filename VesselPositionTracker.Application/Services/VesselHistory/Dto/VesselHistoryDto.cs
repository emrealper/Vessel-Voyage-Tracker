using System;


namespace VesselPositionTracker.Application.Services.VesselHistory.Dto
{
    public class VesselHistoryDto
    {

        public String Id { get; set; }
        public int Mmmsi { get; set; }
        public int? Status { get; set; }
        public int? Speed { get; set; }
        public float? Lon { get; set; }
        public float? Lat { get; set; }
        public int? Course { get; set; }
        public int? Heading { get; set; }

        public DateTime? TimeStamp { get; set; }
        public int ShipId { get; set; }


        public int? WindAngle { get; set; }
        public int? WindSpeed { get; set; }
        public int? WindTemp { get; set; }


    }
}
