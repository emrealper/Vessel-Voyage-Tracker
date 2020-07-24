using System.Collections.Generic;
using System.Threading.Tasks;
using VesselPositionTracker.Domain.Common;

namespace VesselPositionTracker.Application.Common.Interfaces
{
    public interface IGenericRepository<T> where T : IEntity
    {
        //Task<T> Get(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> Add(T entity);
        //Task<int> Delete(int id);
        //Task<int> Update(T entity);
    }
}
