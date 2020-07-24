using MediatR;
using System.Collections.Generic;
using VesselPositionTracker.Application.Services.Fleet.ViewModel;

namespace VesselPositionTracker.Application.Tasks.Queries
{
    public class GetAllFleetsQuery: IRequest<FleetListVm>
    {
    }
}
