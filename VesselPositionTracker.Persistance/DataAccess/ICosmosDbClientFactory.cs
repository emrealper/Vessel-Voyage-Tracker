

namespace VesselPositionTracker.Persistance.DataAccess
{
    public interface ICosmosDbClientFactory
    {
        ICosmosDbClient GetClient(string collectionName);
    }
}
