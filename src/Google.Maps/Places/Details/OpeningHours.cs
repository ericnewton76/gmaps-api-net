using Newtonsoft.Json;

namespace Google.Maps.Places.Details
{
	public class OpeningHours
	{
		/// <summary>
		/// OpenNow is a boolean value indicating if the place is open at the current time.
		/// </summary>
		[JsonProperty("open_now")]
		public bool OpenNow { get; set; }

		/// <summary>
		/// Periods is an array of opening periods covering seven days, starting from Sunday, in chronological order.
		/// </summary>
		[JsonProperty("periods")]
		public Period[] Periods { get; set; }

		/// <summary>
		/// WeekdayText is an array of seven strings representing the formatted opening hours
		/// for each day of the week. If a language parameter was specified in the Place Details
		/// request, the Places Service will format and localize the opening hours appropriately
		/// for that language. The ordering of the elements in this array depends on the Language
		/// parameter. Some languages start the week on Monday while others start on Sunday.
		/// </summary>
		[JsonProperty("weekday_text")]
		public string[] WeekdayText { get; set; }
	}
}
