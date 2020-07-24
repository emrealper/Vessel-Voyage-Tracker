using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using VesselPositionTracker.Application.Common.Interfaces;
using VesselPositionTracker.Domain.Entities;

namespace VesselPositionTracker.Persistance.Repositories
{
  public  class VesselRepository :IVesselRepository
    {

        private readonly IConnectionFactory _connectionFactory;
        private readonly IDbConnection _dbConnection;



        public VesselRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _dbConnection = connectionFactory.GetVesselPositionTrackerConnection;
        }

        public async Task<IEnumerable<Vessel>> GetAllAsync()
        {
            var sql = "SELECT * FROM Vessel;";
            var result = await _dbConnection.QueryAsync<Vessel>(sql);
            return result;
        }


        public async Task<int> Add(Vessel entity)
        {
          
            var sql = "INSERT INTO Vessel (VesselId, Mmmsi, VesselTypeId, Imo, FleetId,Name,PlaceOfBuild,Build,BreadthExtreme,SummerDwt" +
                ",DisplacementSummer,CallSign,Flag,Draught,LengthOverall,FuelConsumption,SpeedMax,SpeedService" +
                ",LiquidOil,Owner,Manager,ManagerOwner,Active" +
                ") " +
                "Values (@VesselId, @Mmmsi, @VesselTypeId, @Imo, @FleetId,@Name,@PlaceOfBuild,@Build,@BreadthExtreme,@SummerDwt," +
                "@DisplacementSummer,@CallSign,@Flag,@Draught,@LengthOverall,@FuelConsumption,@SpeedMax,@SpeedService," +
                "@LiquidOil,@Owner,@Manager,@ManagerOwner,@Active);";

            var affectedRows = await _dbConnection.ExecuteAsync(sql, entity);
            return affectedRows;

          
        }
    }
}
