using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Api.Maps.Service;

namespace Google.Api.Maps.Service.Direction
{
    public class DirectionRequest
    {
        public Waypoint Origin { get; set; }
        public Waypoint Destination { get; set; }

        public TravelMode Mode { get; set; }

        /// <see cref="http://code.google.com/apis/maps/documentation/directions/#RequestParameters"/>
        public string Bounds { get; set; }

        /// <see cref="http://code.google.com/apis/maps/documentation/directions/#RequestParameters"/>
        public string Region { get; set; }

        /// <see cref="http://code.google.com/apis/maps/documentation/directions/#RequestParameters"/>
        public string Language { get; set; }

        public bool Sensor { get; set; }

        private SortedList<int, Waypoint> waypoints;
        public SortedList<int, Waypoint> Waypoints
        {
            get
            {
                if (waypoints == null)
                {
                    waypoints = new SortedList<int, Waypoint>();
                }
                return waypoints;
            }
            set
            {
                waypoints = value;
            }
        }

        public void Add(Waypoint location)
        {
            Waypoints.Add(Waypoints.Count, location);
        }

        internal string WaypointsToUri()
        {
            if (Waypoints.Count == 0) return string.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (Waypoint waypoint in Waypoints.Values)
            {
                sb.AppendFormat("{0}|", waypoint.ToString());
            }
            sb = sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        internal Uri ToUri()
        {
            var url = "json?"
                .Append("origin=", Origin.ToString())
                .Append("destination=", Destination.ToString())
                .Append("mode=", Mode.ToString())
                .Append("waypoints=", WaypointsToUri())
                .Append("region=", Region)
                .Append("language=", Language)
                .Append("sensor=", Sensor? "true":"false")
                .TrimEnd('&');

            return new Uri(url, UriKind.Relative);
        }
    }
}
