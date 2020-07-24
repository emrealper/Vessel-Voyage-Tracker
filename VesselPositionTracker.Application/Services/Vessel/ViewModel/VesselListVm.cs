
using System;
using System.Collections.Generic;
using System.Text;
using VesselPositionTracker.Application.Services.Vessel.Dto;



namespace VesselPositionTracker.Application.Services.Vessel.ViewModel
{
   public class VesselListVm
    {

        public IList<VesselDto> Vessels { get; set; }

    }
}
