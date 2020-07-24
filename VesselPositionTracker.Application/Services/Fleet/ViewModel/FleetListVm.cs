
using System;
using System.Collections.Generic;
using System.Text;
using VesselPositionTracker.Application.Services.Fleet.Dto;



namespace VesselPositionTracker.Application.Services.Fleet.ViewModel
{
   public class FleetListVm
    {

        public IList<FleetDto> Fleets { get; set; }

    }
}
