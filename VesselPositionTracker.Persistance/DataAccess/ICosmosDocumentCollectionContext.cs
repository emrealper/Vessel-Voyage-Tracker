
using Microsoft.Azure.Documents;
using VesselPositionTracker.Domain.Common;

namespace VesselPositionTracker.Persistance.DataAccess
{
    public interface ICosmosDocumentCollectionContext<in T> where T : ICosmosEntity
    {
        string CollectionName { get; }

        string GenerateId(T entity);

        PartitionKey ResolvePartitionKey(string entityId);
    }
}
