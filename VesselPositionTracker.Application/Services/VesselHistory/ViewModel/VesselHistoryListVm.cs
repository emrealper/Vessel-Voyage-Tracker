
using System;
using System.Collections.Generic;

using VesselPositionTracker.Application.Services.VesselHistory.Dto;

namespace VesselPositionTracker.Application.Services.VesselHistory.ViewModel
{
   public class VesselHistoryListVm
    {

        public IList<VesselHistoryDto> VesselHistories { get; set; }

    }
}
