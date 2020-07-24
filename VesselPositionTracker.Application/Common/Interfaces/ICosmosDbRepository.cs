using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesselPositionTracker.Domain.Common;
using VesselPositionTracker.Domain.Entities;

namespace VesselPositionTracker.Application.Common.Interfaces
{
    public interface ICosmobDbRepository<T> where T :ICosmosEntity
    {
        Task<T> GetByIdAsync(string id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        Task<int> BatchUploadAsync(List<ICosmosEntity> entities);

        Task<IEnumerable<VesselHistory>> ReadByQueryAsync(string query);
    }
}
