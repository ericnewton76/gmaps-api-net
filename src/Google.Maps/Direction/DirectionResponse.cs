using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Google.Maps.Direction
{
	[JsonObject(MemberSerialization.OptIn)]
	public class DirectionResponse
	{
		[JsonProperty("geocoded_waypoints")]
		public GeocodedWaypoint[] GeocodedWaypoints { get; set; }

		[JsonProperty("status")]
		public ServiceResponseStatus Status { get; set; }

		[JsonProperty("routes")]
		public DirectionRoute[] Routes { get; set; }
	}

	public class GeocodedWaypoint
	{
		[JsonProperty("partial_match")]
		public bool PartialMatch { get; set; }
	}
}
