using System;

namespace cars.exception
{
    public class IncidentNumberNotFoundException : Exception
    {
        public IncidentNumberNotFoundException(string message) : base(message) { }

    }
}
