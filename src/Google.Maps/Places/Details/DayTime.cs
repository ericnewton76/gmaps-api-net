using Newtonsoft.Json;

namespace Google.Maps.Places.Details
{
	public class DayTime
	{
		/// <summary>
		/// Day is a number from 0–6, corresponding to the days of the week,
		/// starting on Sunday. For example, 2 means Tuesday.
		/// </summary>
		[JsonProperty("day")]
		public int Day { get; set; }

		/// <summary>
		/// time may contain a time of day in 24-hour hhmm format.
		/// Values are in the range 0000–2359.
		/// The time will be reported in the place’s time zone.
		/// </summary>
		[JsonProperty("time")]
		public int Time { get; set; }
	}
}