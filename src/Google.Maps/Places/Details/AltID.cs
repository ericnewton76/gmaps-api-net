using Newtonsoft.Json;

namespace Google.Maps.Places.Details
{
	public class AltID
	{
		/// <summary>
		/// The most likely reason for a place to have an alternative place ID
		/// is if your application adds a place and receives an application-scoped place ID,
		/// then later receives a
		/// Google-scoped place ID after passing the moderation process.
		/// </summary>
		[JsonProperty("place_id")]
		public string PlaceID { get; set; }

		/// <summary>
		/// The scope of an alternative place ID will always be APP, indicating that the alternative
		/// place ID is recognised by your application only.
		/// </summary>
		[JsonProperty("scope")]
		public Scope Scope { get; set; }
	}
}