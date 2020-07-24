using System;


namespace VesselPositionTracker.Application.Services.Fleet.Dto
{
    public class FleetDto
    {

        public Int64 Id { get; set; }
        public int FleetId { get; set; }
        public String Name { get; set; }
        public int Active { get; set; }
        public DateTime Created { get; set; }
        public int Default { get; set; }


    }
}
