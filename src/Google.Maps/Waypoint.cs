using System;

namespace Google.Maps
{

	[Obsolete("Functionality was absorbed by Location being polymorphic", true)]
	public class Waypoint
	{
		/// <summary>
		/// latitude/longitude coordinates
		/// </summary>
		public LatLng Position { get; set; }

		/// <summary>
		/// Origins, destinations, place IDs and waypoints as text strings (e.g. "Chicago, IL" or "Darwin, NT, Australia")
		/// </summary>
		public string Address { get; set; }

		public Waypoint() { }

		public Waypoint(decimal lat, decimal lng)
		{
			Position = new LatLng(lat, lng);
		}

		public Waypoint(string address)
		{
			Address = address;
		}

		/// <summary>
		/// Get the Waypoint value through only the ToString method to keep its result consistent regardless of input type
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Position != null ? Position.ToString() : Address;
		}
	}
}
