using System;

namespace Google.Maps
{
	public class Waypoint
	{
		public LatLng Position { get; set; }
		public string Address { get; set; }

		public Waypoint() { }

		public Waypoint(decimal lat, decimal lng)
		{
			Position = new LatLng(lat, lng);
		}

		public override string ToString()
		{
			return Position != null ? Position.ToString() : Address;
		}
	}
}
