using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VesselPositionTracker.Api.Features.Authorization;

using VesselPositionTracker.Application.Services.Vessel.Commands;
using VesselPositionTracker.Application.Services.Vessel.ViewModel;
using VesselPositionTracker.Application.Tasks.Queries;

namespace VesselPositionTracker.Api.Controllers
{
    public class VesselController : BaseController
    {
        [HttpPost]
        [Authorize(Policy = Policies.OnlyThirdParties)]
        public async Task<ActionResult<int>> Create(CreateVesselCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        [Authorize(Policy = Policies.OnlyThirdParties)]
        public async Task<ActionResult<VesselListVm>> GetAll()
        {
            return await Mediator.Send(new GetAllVesselsQuery());
        }
    }
}