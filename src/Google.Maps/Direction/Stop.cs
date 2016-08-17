using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Google.Maps.Direction
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Stop
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("location")]
		public LatLng Location { get; set; }
	}
}
