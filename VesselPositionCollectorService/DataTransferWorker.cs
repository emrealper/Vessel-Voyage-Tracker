using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Coravel.Invocable;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VesselPositionTracker.Application.Common.Interfaces;
using VesselPositionTracker.Domain.Common;
using VesselPositionTracker.Domain.Entities;
using VesselPositionTracker.Persistance.DataHelpers;

namespace VesselPositionCollectorService
{
    public class DataTransferWorker : IInvocable
    {
        private readonly ILogger<DataTransferWorker> _logger;
        private readonly IS3Service _s3Service;
        private readonly IDeserializeJsonLine<VesselHistory> _deserializeJsonLine;

        private readonly IVesselHistoryRepository _vesselHistoryRepository;

        private const string _bucket = "vesselmovementhistory";
        public DataTransferWorker(ILogger<DataTransferWorker> logger,
               IDeserializeJsonLine<VesselHistory> deserializeJsonLine,
            IS3Service s3Service,
            IVesselHistoryRepository vesselHistoryRepository)
        {
            _logger = logger;
            _deserializeJsonLine = deserializeJsonLine;
            _s3Service = s3Service;
            _vesselHistoryRepository = vesselHistoryRepository;

        }

        public async Task Invoke()
        {

            List<Task> TaskList = new List<Task>();

            _logger.LogInformation($"File Execution started at {DateTime.Now}");

            Parallel.ForEach(await _s3Service.GetFilesFromBucket(_bucket), path =>
            {

     TaskList.Add(this.ExecuteFile(path));
            });



            if (TaskList != null && TaskList.Count != 0)
            {
                await Task.WhenAll(TaskList.ToArray());
                _logger.LogInformation($"All Files has been executed at {DateTime.Now}");

               
            }
            else
            {
                _logger.LogWarning("Files not found on the directory");
            }



        }


        private async Task ExecuteFile (string path)
        {



      
            List<ICosmosEntity> vesselMovements = new List<ICosmosEntity>();
            try
            {
                await foreach (string vesselTrackLine in _s3Service.ReadLinesFromLineDelimetedJsonFile(_bucket, path))
                {

                    VesselHistory entity = _deserializeJsonLine.Serialize(vesselTrackLine);
                  
                    if (entity != null)
                    {
                        entity.Id = $"{entity.Mmmsi}:{Guid.NewGuid()}";
                        vesselMovements.Add(entity);
                    }
                }
                
             var result = await _vesselHistoryRepository.BatchUploadAsync(vesselMovements);
                _logger.LogInformation($"{result} Number of historical data for " +
                    $"MMSI {path.Split('_')[1]} has been pushed to the Azure Commos Db");


            }
            catch(Exception exx)
            {
                _logger.LogWarning(exx.Message.ToString());
            }

         }

    }
}
