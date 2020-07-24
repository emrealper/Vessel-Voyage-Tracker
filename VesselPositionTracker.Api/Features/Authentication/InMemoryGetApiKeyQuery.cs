using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VesselPositionTracker.Api.Features.Authorization;

namespace VesselPositionTracker.Api.Features.Authentication
{
    public class InMemoryGetApiKeyQuery : IGetApiKeyQuery
    {
        private readonly IDictionary<string, ApiKey> _apiKeys;

        public InMemoryGetApiKeyQuery()
        {
            var existingApiKeys = new List<ApiKey>
            {
              
               
                new ApiKey(4, "Some Third Party", "UA872902-6396-46ZC-79F0-FX1BE900591B", new DateTime(2020,07,01),
                    new List<string>
                    {
                        Roles.ThirdParty
                    })
            };

            _apiKeys = existingApiKeys.ToDictionary(x => x.Key, x => x);
        }

        public Task<ApiKey> Execute(string providedApiKey)
        {
            _apiKeys.TryGetValue(providedApiKey, out var key);
            return Task.FromResult(key);
        }
    }
}
