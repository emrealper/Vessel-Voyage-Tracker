using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using VesselPositionTracker.Application.Common.Interfaces;
using VesselPositionTracker.Domain.Entities;

namespace VesselPositionTracker.Persistance.Repositories
{
    public class FleetRepository : IFleetRepository
    {

        private readonly IConnectionFactory _connectionFactory;
        private readonly IDbConnection _dbConnection;



        public FleetRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _dbConnection = connectionFactory.GetVesselPositionTrackerConnection;
        }


        public async Task<IEnumerable<Fleet>> GetAllAsync()
        {
            var sql = "SELECT * FROM Fleet;";
            var result = await _dbConnection.QueryAsync<Fleet>(sql);
            return result;
        }

        public async Task<int> Add(Fleet entity)
        {

            entity.Created = DateTime.Now;

            var sql = "INSERT INTO Fleet (FleetId, Name, Active, Created, [Default]) values (@FleetId, @Name, @Active, @Created, @Default);";

            var affectedRows = await _dbConnection.ExecuteAsync(sql, entity);
            return affectedRows;


        }
    }
}
