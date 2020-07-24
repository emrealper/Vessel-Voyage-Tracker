using Microsoft.AspNetCore.Authorization;

namespace VesselPositionTracker.Api.Features.Authorization
{
    public class OnlyThirdPartiesRequirement : IAuthorizationRequirement
    {
    }
}
