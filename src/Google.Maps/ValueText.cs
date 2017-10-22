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
		public long Value { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		public override string ToString()
		{
			return String.Format("{0} ({1})", Text, Value);
		}
	}
}
