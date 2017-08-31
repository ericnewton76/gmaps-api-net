using Newtonsoft.Json;

namespace Google.Maps.Roads
{
	[JsonObject(MemberSerialization.OptIn)]
	public class SnapToRoadsResponse
	{
		[JsonProperty("snappedPoints")]
		public SnappedPoint[] SnappedPoints { get; set; }
	}
}