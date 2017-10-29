using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Google.Maps.Common;

namespace Google.Maps.Direction
{
	public class GeocodedWaypoint
	{
		[JsonProperty("geocoder_status")]
		public ServiceResponseStatus Status { get; set; }

		[JsonProperty("place_id")]
		public string PlaceId { get; set; }

		[JsonProperty("types")]
		public AddressType[] Types { get; set; }

		[JsonProperty("partial_match")]
		public bool PartialMatch { get; set; }
	}
}
