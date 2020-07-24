using MediatR;
using System;
using System.Collections.Generic;

using VesselPositionTracker.Application.Services.Vessel.Dto;
using VesselPositionTracker.Application.Services.Vessel.ViewModel;

namespace VesselPositionTracker.Application.Tasks.Queries
{
    public class GetAllVesselsQuery: IRequest<VesselListVm>
    {

      
    }
}
