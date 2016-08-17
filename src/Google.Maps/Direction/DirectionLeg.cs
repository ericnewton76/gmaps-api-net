using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Google.Maps.Direction
{
	[JsonObject(MemberSerialization.OptIn)]
	public class DirectionLeg
	{
		[JsonProperty("steps")]
		public DirectionStep[] Steps { get; set; }

		[JsonProperty("duration")]
		public ValueText Duration { get; set; }

		[JsonProperty("distance")]
		public ValueText Distance { get; set; }

		[JsonProperty("start_location")]
		public LatLng StartLocation { get; set; }

		[JsonProperty("end_location")]
		public LatLng EndLocation { get; set; }

		[JsonProperty("start_address")]
		public string StartAddress { get; set; }

		[JsonProperty("end_address")]
		public string EndAddress { get; set; }

		[JsonProperty("arrival_time")]
		public Time ArrivalTime { get; set; }

		[JsonProperty("departure_time")]
		public Time DepartureTime { get; set; }
	}
}
