namespace VesselPositionTracker.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IFleetRepository Fleets { get; }



        IVesselRepository Vessels { get; }


    }
}