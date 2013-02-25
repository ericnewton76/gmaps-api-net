using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Google.Maps.Direction
{
	[JsonObject(MemberSerialization.OptIn)]
	public class DirectionResponse
	{
		[JsonProperty("status")]
		public ServiceResponseStatus Status { get; set; }

		[JsonProperty("routes")]
		public DirectionRoute[] Routes { get; set; }
	}
}
