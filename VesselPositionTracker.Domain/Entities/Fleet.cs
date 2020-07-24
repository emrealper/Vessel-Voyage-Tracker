using System;
using System.Collections.Generic;
using System.Text;
using VesselPositionTracker.Domain.Common;

namespace VesselPositionTracker.Domain.Entities
{
    public class Fleet : IEntity
    {
        public Int64 Id { get; set; }
        public int FleetId { get; set; }
        public String Name { get; set; }
        public int Active { get; set; }
        public DateTime Created { get; set; }
        public int Default { get; set; }


    }
}
