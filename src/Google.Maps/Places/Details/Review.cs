using Newtonsoft.Json;

namespace Google.Maps.Places.Details
{
	public class Review
	{
		/// <summary>
		/// aspects contains a collection of AspectRating objects,
		/// each of which provides a rating of a single attribute of the establishment.
		/// The first object in the collection is considered the primary aspect.
		/// </summary>
		[JsonProperty("aspects")]
		public AspectRating[] Aspects { get; set; }

		/// <summary>
		/// The name of the user who submitted the review.
		/// Anonymous reviews are attributed to "A Google user".
		/// </summary>
		[JsonProperty("author_name")]
		public string AuthorName { get; set; }

		/// <summary>
		/// The URL to the users Google+ profile, if available.
		/// </summary>
		[JsonProperty("author_url")]
		public string AuthorURL { get; set; }

		/// <summary>
		/// An IETF language code indicating the language used in the user's review.
		/// This field contains the main language tag only, and not the secondary tag
		/// indicating country or region. For example, all the English reviews are tagged
		/// as 'en', and not 'en-AU' or 'en-UK' and so on.
		/// </summary>
		[JsonProperty("language")]
		public string Language { get; set; }

		/// <summary>
		/// The user's overall rating for this place.
		/// This is a whole number, ranging from 1 to 5.
		/// </summary>
		[JsonProperty("rating")]
		public int rating { get; set; }

		/// <summary>
		/// the user's review. When reviewing a location with Google Places,
		/// text reviews are considered optional. Therefore, this field may by empty.
		/// Note that this field may include simple HTML markup. For example,
		/// the entity reference &amp; may represent an ampersand character.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// The time that the review was submitted, measured in the number of seconds
		/// since since midnight, January 1, 1970 UTC.
		/// </summary>
		[JsonProperty("time")]
		public int Time { get; set; }
	}
}