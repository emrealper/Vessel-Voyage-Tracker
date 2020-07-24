using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VesselPositionTracker.Api.Features.Authorization;
using VesselPositionTracker.Application.Services.Fleet.Commands;
using VesselPositionTracker.Application.Services.Fleet.ViewModel;
using VesselPositionTracker.Application.Tasks.Queries;

namespace VesselPositionTracker.Api.Controllers
{
    public class FleetController : BaseController
    {
        [HttpPost]
        [Authorize(Policy = Policies.OnlyThirdParties)]
        public async Task<ActionResult<int>> Create(CreateFleetCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        [Authorize(Policy = Policies.OnlyThirdParties)]
        public async Task<ActionResult<FleetListVm>> GetAll()
        {
            return await Mediator.Send(new GetAllFleetsQuery());
        }

    }
}