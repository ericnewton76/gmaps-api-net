using Newtonsoft.Json;

namespace Google.Maps.Places
{
	public class AutocompleteResponse
	{
		[JsonProperty("status")]
		public ServiceResponseStatus Status { get; set; }

		[JsonProperty("error_message")]
		public string ErrorMessage { get; set; }

		[JsonProperty("predictions")]
		public AutocompleteResult[] Predictions { get; set; }
	}
}
