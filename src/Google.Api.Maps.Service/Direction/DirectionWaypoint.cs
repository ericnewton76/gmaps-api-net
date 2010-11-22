using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Api.Maps.Service.Direction
{
    public class DirectionWaypoint
    {
        public DirectionWaypoint(){}

        public DirectionWaypoint(decimal lat, decimal lng)
        {
            Position = new GeographicPosition(lat, lng);
        }

        public GeographicPosition Position { get; set; }
        
        public string Address { get; set; }

        public override string ToString()
        {
            return Position != null ? Position.ToString() : Address;
        }
    }
}
