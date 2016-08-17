using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;


namespace Google.Maps.Direction
{
	[JsonObject(MemberSerialization.OptIn)]
	public class LineInfo
	{
		[JsonProperty("agencies")]
		public TransitAgency[] Agencies { get; set; }

		[JsonProperty("color")]
		public string Color { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("short_name")]
		public string ShortName { get; set; }

		[JsonProperty("text_color")]
		public string TextColor { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("vehicle")]
		public VehicleInfo Vehicle { get; set; }

	}
}