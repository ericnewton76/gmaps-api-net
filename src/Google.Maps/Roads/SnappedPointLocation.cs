using Newtonsoft.Json;

namespace Google.Maps.Roads
{
	[JsonObject(MemberSerialization.OptIn)]
	public class SnappedPointLocation
	{
		[JsonProperty("latitude")]
		public double Latitude { get; set; }

		[JsonProperty("longitude")]
		public double Longitude { get; set; }
	}
}