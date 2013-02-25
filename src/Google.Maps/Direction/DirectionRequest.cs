using System;
using System.Collections.Generic;
using System.Text;
using Google.Maps;
using System.ComponentModel;

namespace Google.Maps.Direction
{
	public class DirectionRequest
	{
		/// <summary>
		/// The <see cref="Location"/> from which you wish to calculate directions.
		/// </summary>
		public Location Origin { get; set; }
		/// <summary>
		/// The <see cref="Location"/> from which you wish to calculate directions.
		/// </summary>
		public Location Destination { get; set; }

		/// <summary>
		/// Specifies the mode of transport to use when calculating directions. Valid values are specified in <see cref="TravelMode"/>s. 
		/// </summary>
		//TODO: add transit TravelMode and add to summary: If you set the mode to "transit" you must also specify either a departure_time or an arrival_time.
		[DefaultValue(TravelMode.driving)]
		public TravelMode Mode { get; set; }

		/// <summary>The region code, specified as a ccTLD ("top-level domain") two-character value. See also Region biasing.</summary>
		/// <see cref="http://code.google.com/apis/maps/documentation/directions/#RequestParameters"/>
		/// <seealso cref="https://developers.google.com/maps/documentation/directions/#RegionBiasing"/>
		public string Region { get; set; }

		/// <summary>The language in which to return results. See the list of supported domain languages. 
		/// Note that we often update supported languages so this list may not be exhaustive. 
		/// If language is not supplied, the service will attempt to use the native language of the domain from which the request is sent.</summary>
		/// <see cref="http://code.google.com/apis/maps/documentation/directions/#RequestParameters"/>
		public string Language { get; set; }

		/// <summary>
		///  Indicates whether or not the directions request comes from a device with a location sensor. This value must be either true or false.
		/// </summary>
		public bool? Sensor { get; set; }

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
			EnsureSensor();

			var qsb = new Google.Maps.Internal.QueryStringBuilder()
				.Append("origin", (Origin == null ? (string)null : Origin.GetAsUrlParameter()))
				.Append("destination", (Destination == null ? (string)null : Destination.GetAsUrlParameter()))
				.Append("mode", (Mode != TravelMode.driving ? Mode.ToString() : (string)null))
				.Append("waypoints", WaypointsToUri())
				.Append("region", Region)
				.Append("language", Language)
				.Append("sensor", Sensor.Value ? "true" : "false");

			var url = "json?" + qsb.ToString();

			return new Uri(url, UriKind.Relative);
		}

		private void EnsureSensor()
		{
			if (this.Sensor == null) throw new InvalidOperationException("Sensor property hasn't been set.");
		}

	}
}
