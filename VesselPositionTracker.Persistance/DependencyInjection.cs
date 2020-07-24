
using Microsoft.Extensions.DependencyInjection;
using VesselPositionTracker.Application.Common.Interfaces;
using VesselPositionTracker.Persistance.DataAccess;
using VesselPositionTracker.Persistance.Repositories;

namespace VesselPositionTracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IVesselRepository, VesselRepository>();
            services.AddTransient<IFleetRepository, FleetRepository>();
            services.AddTransient<IVesselHistoryRepository, VesselHistoryRepository>();
        
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        } 
    }
}
