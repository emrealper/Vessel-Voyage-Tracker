

using System;
using Microsoft.Azure.Documents;
using VesselPositionTracker.Application.Common.Interfaces;
using VesselPositionTracker.Domain.Entities;
using VesselPositionTracker.Persistance.DataAccess;

namespace VesselPositionTracker.Persistance.Repositories
{
    public class VesselHistoryRepository : CosmosDbRepository<VesselHistory> , IVesselHistoryRepository
    {
        public VesselHistoryRepository(ICosmosDbClientFactory factory) : base(factory) { }

        public override string CollectionName { get; } = "vesselhistory";
        public override string GenerateId(VesselHistory entity) => $"{entity.Mmmsi}:{Guid.NewGuid()}";
        public override PartitionKey ResolvePartitionKey(string entityId) => new PartitionKey(entityId.Split(':')[0]);
    }
}
