using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VesselPositionTracker.Domain.Enums;

namespace VesselPositionTracker.Application.Services.Fleet.Commands
{
   public class CreateFleetCommand : IRequest<int>
    {

        public int FleetId { get; set; }



        public String Name { get; set; }
    

 



        public int Active { get; set; }

        public int Default { get; set; }

    }
}
