

using VesselPositionTracker.Application.Common.Interfaces;

namespace VesselPositionTracker.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IFleetRepository FleetRepository,
            IVesselRepository VesselRepository 

 

            )
        {
            Fleets = FleetRepository;
            Vessels = VesselRepository;


        }
        public IFleetRepository Fleets { get; }
        public IVesselRepository Vessels { get; }



 
    }
}
