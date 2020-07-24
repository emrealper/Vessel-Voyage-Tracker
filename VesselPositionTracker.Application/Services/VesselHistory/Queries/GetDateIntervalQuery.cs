using MediatR;
using System;
using VesselPositionTracker.Application.Services.VesselHistory.ViewModel;

namespace VesselPositionTracker.Application.Tasks.Queries
{
    public class GetDateIntervalQuery: IRequest<VesselHistoryListVm>
    {
        public DateTime Begin { get; set; }

        public DateTime End { get; set; }
    }
}
