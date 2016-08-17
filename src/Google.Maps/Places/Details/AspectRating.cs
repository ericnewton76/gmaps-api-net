using Newtonsoft.Json;

namespace Google.Maps.Places.Details
{
	public class AspectRating
	{
		/// <summary>
		/// type the name of the aspect that is being rated.
		/// The following types are supported: appeal, atmosphere, decor,
		/// facilities, food, overall, quality and service.
		/// </summary>
		[JsonProperty("type")]
		public AspectType Type { get; set; }

		/// <summary>
		/// The user's rating for this particular aspect, from 0 to 3.
		/// </summary>
		[JsonProperty("rating")]
		public int Rating { get; set; }
	}
}