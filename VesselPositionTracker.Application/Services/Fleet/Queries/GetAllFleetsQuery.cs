using MediatR;
using System.Collections.Generic;
using VesselPositionTracker.Application.Services.Fleet.ViewModel;

namespace VesselPositionTracker.Application.Services.Queries
{
    public class GetAllFleetsQuery: IRequest<FleetListVm>
    {
    }
}
