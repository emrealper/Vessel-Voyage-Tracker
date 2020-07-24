using System;
using System.Collections.Generic;
using System.Text;
using VesselPositionTracker.Domain.Common;

namespace VesselPositionTracker.Application.Common.Interfaces
{
    public interface IDeserializeJsonLine<E>
                where E : class, IEntity
    {

        E Serialize(string line);

        E Serialize(string line, string dateFormat);
    }
}
