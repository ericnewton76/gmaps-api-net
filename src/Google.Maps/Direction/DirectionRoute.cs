using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Google.Maps.Direction
{
	[JsonObject(MemberSerialization.OptIn)]
	public class DirectionRoute
	{
		[JsonProperty("summary")]
		public string Summary { get; set; }

		[JsonProperty("legs")]
		public DirectionLeg[] Legs { get; set; }

		[JsonProperty("copyrights")]
		public string Copyrights { get; set; }

		[JsonProperty("overview_polyline")]
		public Polyline OverviewPolyline { get; set; }
	}
}
