using Newtonsoft.Json;

namespace Google.Maps.Direction
{
	[JsonObject(MemberSerialization.OptIn)]
	public class VehicleInfo
	{
		[JsonProperty("icon")]
		public string Icon { get; set; }

		[JsonProperty("local_icon")]
		public string LocalIcon { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}