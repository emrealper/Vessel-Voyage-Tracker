

using System;
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
    public class CosmosDbClient : ICosmosDbClient
    {
        private readonly string _databaseName;
        private readonly string _collectionName;
        private readonly IDocumentClient _documentClient;

        public CosmosDbClient(string databaseName, string collectionName, IDocumentClient documentClient)
        {
            _databaseName = databaseName ?? throw new ArgumentNullException(nameof(databaseName));
            _collectionName = collectionName ?? throw new ArgumentNullException(nameof(collectionName));
            _documentClient = documentClient ?? throw new ArgumentNullException(nameof(documentClient));
        }

        public async Task<Document> ReadDocumentAsync(string documentId, RequestOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _documentClient.ReadDocumentAsync(
                UriFactory.CreateDocumentUri(_databaseName, _collectionName, documentId), options, cancellationToken);
        }




        public async Task<IEnumerable<VesselHistory>> ReadDocumentsByQueryAsync(string query, RequestOptions options = null,
        CancellationToken cancellationToken = default(CancellationToken))
        {

            var option = new FeedOptions { EnableCrossPartitionQuery = true };
            return   _documentClient.CreateDocumentQuery<VesselHistory>(
                UriFactory.CreateDocumentCollectionUri(_databaseName, _collectionName),query,option);
        }




        public async Task<Document> CreateDocumentAsync(object document, RequestOptions options = null,
            bool disableAutomaticIdGeneration = false, CancellationToken cancellationToken = default(CancellationToken))
        {

             

            _documentClient.ConnectionPolicy.RequestTimeout = TimeSpan.FromSeconds(30);
            return await _documentClient.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(_databaseName, _collectionName), document, options,
                disableAutomaticIdGeneration, cancellationToken);
        }


        public async Task<int> BathchUpload(List<ICosmosEntity> documents, RequestOptions options = null,
    bool disableAutomaticIdGeneration = false, CancellationToken cancellationToken = default(CancellationToken))
        {



            _documentClient.ConnectionPolicy.RequestTimeout = TimeSpan.FromSeconds(100000);


            RequestOptions requestOptions = new RequestOptions {
                PartitionKey = new PartitionKey(documents[0].ShipId),
                EnableScriptLogging = true,
                
                
           };
            int pointer = 0;






            while (pointer < documents.Count)
            {
                int count= await _documentClient.ExecuteStoredProcedureAsync<int>(
                UriFactory.CreateStoredProcedureUri(_databaseName, _collectionName, "bulkUpload"),
                requestOptions,
                documents.Skip(pointer).Take(1000));
                pointer += count;
            }

            return pointer;

        }









        public async Task<Document> ReplaceDocumentAsync(string documentId, object document,
            RequestOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _documentClient.ReplaceDocumentAsync(
                UriFactory.CreateDocumentUri(_databaseName, _collectionName, documentId), document, options,
                cancellationToken);
        }

        public async Task<Document> DeleteDocumentAsync(string documentId, RequestOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _documentClient.DeleteDocumentAsync(
                UriFactory.CreateDocumentUri(_databaseName, _collectionName, documentId), options, cancellationToken);
        }
    }
}
