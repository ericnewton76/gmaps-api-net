using Newtonsoft.Json;

namespace Google.Maps.Places.Details
{
	public class Period
	{
		/// <summary>
		/// Open contains a pair of day and time objects describing when the place opens.
		/// </summary>
		[JsonProperty("open")]
		public DayTime Open { get; set; }

		/// <summary>
		/// Close may contain a pair of day and time objects describing when the place closes.
		/// Note: If a place is always open, the Close section will be missing from the response.
		/// Clients can rely on always-open being represented as an Open period containing day with
		/// value 0 and time with value 0000, and no Close.
		/// </summary>
		[JsonProperty("close")]
		public DayTime Close { get; set; }
	}
}