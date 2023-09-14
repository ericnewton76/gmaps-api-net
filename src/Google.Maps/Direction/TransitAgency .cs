using Newtonsoft.Json;


namespace Google.Maps.Direction
{
	[JsonObject(MemberSerialization.OptIn)]
	public class TransitAgency
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }
	}
}