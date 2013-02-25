using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Google.Maps
{
	[JsonObject(MemberSerialization.OptIn)]
	public class ValueText
	{
		[JsonProperty("value")]
		public string Value { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
