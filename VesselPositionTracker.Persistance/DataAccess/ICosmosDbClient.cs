
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using VesselPositionTracker.Domain.Common;
using VesselPositionTracker.Domain.Entities;

namespace VesselPositionTracker.Persistance.DataAccess
{
    public interface ICosmosDbClient 
    {
        Task<Document> ReadDocumentAsync(string documentId, RequestOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<Document> CreateDocumentAsync(object document, RequestOptions options =null,
            bool disableAutomaticIdGeneration = false,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<Document> ReplaceDocumentAsync(string documentId, object document, RequestOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<Document> DeleteDocumentAsync(string documentId, RequestOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> BathchUpload(List<ICosmosEntity> documents, RequestOptions options = null,
          bool disableAutomaticIdGeneration = false, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<VesselHistory>> ReadDocumentsByQueryAsync(string query, RequestOptions options = null,
             CancellationToken cancellationToken = default(CancellationToken));

    }
}
