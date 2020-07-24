using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesselPositionTracker.Application.Common.Interfaces
{
    public interface IConnectionFactory : IDisposable
    {
        IDbConnection GetVesselPositionTrackerConnection { get; }
    }
}
