

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
//using TodoService.Core.Exceptions;
using VesselPositionTracker.Application.Common.Interfaces;
using VesselPositionTracker.Domain.Common;
using VesselPositionTracker.Domain.Entities;
using VesselPositionTracker.Persistance.DataAccess;

namespace VesselPositionTracker.Persistance.Repositories
{
    public abstract class CosmosDbRepository<T> : ICosmobDbRepository<T>, ICosmosDocumentCollectionContext<T>
        where T : class,ICosmosEntity
    {
        private readonly ICosmosDbClientFactory _cosmosDbClientFactory;

        protected CosmosDbRepository(ICosmosDbClientFactory cosmosDbClientFactory)
        {
            _cosmosDbClientFactory = cosmosDbClientFactory;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            try
            {
                var cosmosDbClient = _cosmosDbClientFactory.GetClient(CollectionName);
                var document = await cosmosDbClient.ReadDocumentAsync(id, new RequestOptions
                {
                    PartitionKey = ResolvePartitionKey(id)
                });

                return JsonConvert.DeserializeObject<T>(document.ToString());
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    //throw new EntityNotFoundException();
                }

                throw;
            }
        }


        public async Task<IEnumerable<VesselHistory>> ReadByQueryAsync(string query)
        {
            try
            {
                var cosmosDbClient = _cosmosDbClientFactory.GetClient(CollectionName);
                return await cosmosDbClient.ReadDocumentsByQueryAsync(query);

               

            
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    //throw new EntityNotFoundException();
                }

                throw;
            }
        }



        public async Task<T> AddAsync(T entity)
        {
            try
            {
                entity.Id = GenerateId(entity);
                var cosmosDbClient = _cosmosDbClientFactory.GetClient(CollectionName);

               

                 var document = await cosmosDbClient.CreateDocumentAsync(entity);
               
                return JsonConvert.DeserializeObject<T>(document.ToString());
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.Conflict)
                {
                    //throw new EntityAlreadyExistsException();
                }

                throw;
            }
        }


        public async Task<int> BatchUploadAsync(List<ICosmosEntity> entities)
        {
            try
            {
                
                var cosmosDbClient = _cosmosDbClientFactory.GetClient(CollectionName);



                var result = await cosmosDbClient.BathchUpload(entities);

                return result;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.Conflict)
                {
                    //throw new EntityAlreadyExistsException();
                }

                throw;
            }
        }



        public async Task UpdateAsync(T entity)
        {
            try
            {
                var cosmosDbClient = _cosmosDbClientFactory.GetClient(CollectionName);
                await cosmosDbClient.ReplaceDocumentAsync(entity.Id, entity);
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    //throw new EntityNotFoundException();
                }

                throw;
            }
        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                var cosmosDbClient = _cosmosDbClientFactory.GetClient(CollectionName);
                await cosmosDbClient.DeleteDocumentAsync(entity.Id, new RequestOptions
                {
                    PartitionKey = ResolvePartitionKey(entity.Id)
                });
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    //throw new EntityNotFoundException();
                }

                throw;
            }
        }

        public abstract string CollectionName { get; }
        public virtual string GenerateId(T entity) => Guid.NewGuid().ToString();
        public virtual PartitionKey ResolvePartitionKey(string entityId) => null;
    }
}
