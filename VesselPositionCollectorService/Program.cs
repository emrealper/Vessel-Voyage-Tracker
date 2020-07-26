using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coravel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Hosting;
using NLog.Extensions.Logging;
using System.IO;
using System.Diagnostics;
using VesselPositionTracker.Application.Common.Interfaces;
using VesselPositionTracker.Persistance.Services;
using VesselPositionTracker.Domain.Entities;
using VesselPositionTracker.Persistance.DataHelpers;
using System.Configuration;
using VesselPositionCollectorService.Options;
using VesselPositionCollectorService.Extensions;
using VesselPositionTracker.Persistance.Repositories;

namespace VesselPositionCollectorService
{
    public class Program
    {
        public static void Main(string[] args)
        {
    



            var config = new ConfigurationBuilder()

        .AddJsonFile("appsettings.json", optional: false)
        .Build();

            string cronExpression = config.GetSection("schedulingConfiguration:Cron").Value;


            IHost host = CreateHostBuilder(args).Build();


            host.Services.UseScheduler(scheduler =>
            {

                scheduler
    .Schedule<DataTransferWorker>()
    .Cron(cronExpression)
    .Zoned(TimeZoneInfo.Local);
            });


            host.Run();



        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            .UseNLog()
            .ConfigureServices((hostContext, services) =>
            {


                var connectionStringsOptions =
                 hostContext.Configuration.GetSection("ConnectionStrings").Get<ConnectionStringsOptions>();
                var cosmosDbOptions = hostContext.Configuration.GetSection("CosmosDb").Get<CosmosDbOptions>();
                var (serviceEndpoint, authKey) = connectionStringsOptions.ActiveConnectionStringOptions;
                var (databaseName, collectionData) = cosmosDbOptions;
                var collectionNames = collectionData.Select(c => c.Name).ToList();
                var awsS3Options= hostContext.Configuration.GetSection("AwsS3Configuration").Get<AwsS3Options>();

               



                Dictionary<string, string> _attributeMappings = new Dictionary<string, string>
        {

{"Mmmsi","MMSI"},
{"Status","STATUS"},
{"Speed","SPEED"},
{"Lon","LON"},
{"Lat","LAT"},
{"Course","COURSE"},
{"Heading","HEADING"},
{"TimeStamp","TIMESTAMP"},
{"ShipId","SHIP_ID"},
{"WindAngle","WIND_ANGLE"},
{"WindSpeed","WindSPEED"},
{"WindTemp","WIND_TEMP"}



 };


                services.AddLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    loggingBuilder.AddNLog();
                });

                services.AddTransient<IS3Service>(s => new S3Service(awsS3Options.AccessKey,
                    awsS3Options.SecretAccessKey,awsS3Options.ServiceUrl.ToString()));
            
                services.AddCosmosDb(serviceEndpoint, authKey, databaseName, collectionNames);

                services.AddTransient<IDeserializeJsonLine<VesselHistory>>
                (s => new DeserializeJsonLine<VesselHistory>(_attributeMappings));

                services.AddScoped<IVesselHistoryRepository, VesselHistoryRepository>();

                services.AddScheduler();

                services.AddTransient<DataTransferWorker>();





            });




    }
}
