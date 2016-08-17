using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Google.Maps.Direction
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Time
	{
		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("time_zone")]
		public string TimeZone { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }
	}
}
