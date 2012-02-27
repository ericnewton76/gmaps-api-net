using System;

namespace Google.Api.Maps.Service
{
    public class Waypoint
    {
        public GeographicPosition Position { get; set; }
        public string Address { get; set; }

        public Waypoint(){}

        public Waypoint(decimal lat, decimal lng)
        {
            Position = new GeographicPosition(lat, lng);
        }

        public override string ToString()
        {
            return Position != null ? Position.ToString() : Address;
        }
    }
}
