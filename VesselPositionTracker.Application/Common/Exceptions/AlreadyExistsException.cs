

using System;

namespace VesselPositionTracker.Application.Common.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string name, object key)
                  : base($"Entity \"{name}\" ({key}) already exists")
        {
        }
    }
}
