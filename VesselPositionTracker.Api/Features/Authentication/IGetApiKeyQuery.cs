using System.Threading.Tasks;

namespace VesselPositionTracker.Api.Features.Authentication
{
    public interface IGetApiKeyQuery
    {
        Task<ApiKey> Execute(string providedApiKey);
    }
}
