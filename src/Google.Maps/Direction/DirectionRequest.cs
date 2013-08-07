using System;
using System.Collections.Generic;
using System.Text;
using Google.Maps;
using System.ComponentModel;

namespace Google.Maps.Direction
{
    public class DirectionRequest : ApiRequest
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

		private List<Location> _waypoints;
		public IEnumerable<Location> Waypoints
		{
			get
			{
				if (_waypoints == null) return new List<Location>(); //may use a static readonly empty list instead of creating one everytime.
				return (IEnumerable<Location>)_waypoints;
			}
			set
			{
				if (value == null)
				{
					//clear our reference.
					_waypoints = null; return;
				}
				
				//see if reference passed is a List<Location> instance.
				List<Location> list = value as List<Location>;
				
				if(list == null) 
					//build a list from the ienumerable passed in.
					list = new List<Location>(value);

				_waypoints = list;
			}
		}

		/// <summary>
		/// Adds a waypoint to the current request.
		/// </summary>
		/// <remarks>Google's API specifies 8 maximum for non-business (free) consumers, and up to 23 for (registered) business customers</remarks>
		/// <param name="waypoint"></param>
		public void AddWaypoint(Location waypoint)
		{
			if (waypoint == null) return;
			if (_waypoints == null) _waypoints = new List<Location>();
			_waypoints.Add(waypoint);
		}

		internal string WaypointsToUri()
		{
			if (this._waypoints == null || this._waypoints.Count == 0) return null;

			StringBuilder sb = new StringBuilder();

			foreach (Location waypoint in this._waypoints)
			{
				if (sb.Length > 0) sb.Append("|");
				sb.Append(waypoint.ToString());
			}

			return sb.ToString();
		}

		internal override Uri ToUri()
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



	}
}
