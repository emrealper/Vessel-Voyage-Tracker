using MediatR;
using System;
using VesselPositionTracker.Application.Services.VesselHistory.ViewModel;

namespace VesselPositionTracker.Application.Services.VesselHistory.Queries
{
    public class GetDateIntervalQuery: IRequest<VesselHistoryListVm>
    {

        public int Mmsi { get; set; }
        public DateTime Begin { get; set; }

        public DateTime End { get; set; }
    }
}
