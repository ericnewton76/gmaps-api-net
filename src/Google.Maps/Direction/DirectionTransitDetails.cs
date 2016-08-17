using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Google.Maps.Direction
{
	[JsonObject(MemberSerialization.OptIn)]
	public class DirectionTransitDetails
	{
		[JsonProperty("arrival_stop")]
		public Stop ArrivalStop { get; set; }

		[JsonProperty("arrival_time")]
		public Time ArrivalTime { get; set; }

		[JsonProperty("departure_stop")]
		public Stop DepartureStop { get; set; }

		[JsonProperty("departure_time")]
		public Time DepartureTime { get; set; }

		[JsonProperty("headsign")]
		public string HeadSign { get; set; }

		[JsonProperty("line")]
		public LineInfo Line { get; set; }

		[JsonProperty("num_stops")]
		public string NumberOfStops { get; set; }


		public DirectionTransitDetails()
		{

		}


	}
}
