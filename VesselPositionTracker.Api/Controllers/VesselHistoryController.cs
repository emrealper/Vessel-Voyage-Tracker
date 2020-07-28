using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VesselPositionTracker.Api.Features.Authorization;
using VesselPositionTracker.Application.Services.VesselHistory.Queries;
using VesselPositionTracker.Application.Services.VesselHistory.ViewModel;


namespace VesselPositionTracker.Api.Controllers
{
    public class VesselHistoryController : BaseController
    {
        [HttpGet("{Mmsi}/{Begin}/{End}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = Policies.OnlyThirdParties)]
        public async Task<ActionResult<VesselHistoryListVm>> GetAll(int Mmsi,DateTime Begin, DateTime End)
        {
            return await Mediator.Send(new GetDateIntervalQuery
            {
                Mmsi= Mmsi,
                Begin = Begin,
                End = End
            });
        }
    }

}