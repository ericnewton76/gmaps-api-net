using Google.Maps.Shared;
using Newtonsoft.Json;

namespace Google.Maps.Places.Details
{
	public class PlaceDetailsResult
	{
		/// <summary>
		/// AddressComponents is an array of separate address components used to compose a given address.
		/// For example, the address "111 8th Avenue, New York, NY" contains separate address components for
		/// "111" (the street number, "8th Avenue" (the route), "New York" (the city) and "NY" (the US state).
		/// </summary>
		[JsonProperty("address_components")]
		public AddressComponent[] AddressComponents { get; set; }

		/// <summary>
		/// formatted_address is a string containing the human-readable address of this place.
		/// Often this address is equivalent to the "postal address," which sometimes differs
		/// from country to country. This address is generally composed of one or more address_component fields.
		/// </summary>
		[JsonProperty("formatted_address")]
		public string FormattedAddress { get; set; }

		/// <summary>
		/// FormattedPhoneNumber contains the place's phone number in its local format.
		/// For example, the formatted_phone_number for Google's Sydney, Australia office is (02) 9374 4000.
		/// </summary>
		/// <see href="http://en.wikipedia.org/wiki/Local_conventions_for_writing_telephone_numbers"/>
		[JsonProperty("formatted_phone_number")]
		public string FormattedPhoneNumber { get; set; }

		/// <summary>
		/// Geometry contains the following information:
		/// - Location contains the geocoded latitude,longitude value for this place.
		/// </summary>
		[JsonProperty("geometry")]
		public Geometry Geometry { get; set; }

		/// <summary>
		/// Icon contains the URL of a suggested icon which may be displayed to the user when indicating this result on a map.
		/// </summary>
		[JsonProperty("icon")]
		public string icon { get; set; }

		/// <summary>
		/// InternationalPhoneNumber contains the place's phone number in international format.
		/// International format includes the country code, and is prefixed with the plus (+) sign.
		/// For example, the international_phone_number for Google's Sydney, Australia office is +61 2 9374 4000.
		/// </summary>
		[JsonProperty("international_phone_number")]
		public string InternationalPhoneNumber { get; set; }

		/// <summary>
		/// Name contains the human-readable name for the returned result. For establishment results,
		/// this is usually the canonicalized business name.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// An object describing the opening hours of this place.
		/// </summary>
		[JsonProperty("opening_hours")]
		public OpeningHours OpeningHours { get; set; }

		/// <summary>
		/// PermanentlyClosed is a boolean flag indicating whether the place has permanently
		/// shut down (value true). If the place is not permanently closed,
		/// the flag is absent from the response.
		/// </summary>
		[JsonProperty("permanently_closed")]
		public bool PermanentlyClosed { get; set; }

		/// <summary>
		/// an array of photo objects, each containing a reference to an image.
		/// A Place Details request may return up to ten photos. More information
		/// about place photos and how you can use the images in your application
		/// can be found in the Place Photos documentation.
		/// </summary>
		/// <see href="https://developers.google.com/places/web-service/photos"/>
		[JsonProperty("photos")]
		public Photo[] Photos { get; set; }

		/// <summary>
		/// A textual identifier that uniquely identifies a place.
		/// To retrieve information about the place, pass this identifier in
		/// the placeId field of a Places API request. For more information about
		/// place IDs, see the place ID overview.
		/// </summary>
		/// <see href="https://developers.google.com/places/place-id"/>
		[JsonProperty("place_id")]
		public string PlaceID { get; set; }

		/// <summary>
		/// Indicates the scope of the PlaceID.
		/// </summary>
		[JsonProperty("scope")]
		public Scope Scope { get; set; }

		/// <summary>
		/// An array of zero, one or more alternative place IDs for the place,
		/// with a scope related to each alternative ID.
		/// Note: This array may be empty or not present.
		/// </summary>
		[JsonProperty("alt_ids")]
		public AltID[] AltIDs { get; set; }

		/// <summary>
		/// The price level of the place, on a scale of 0 to 4. The exact amount indicated
		/// by a specific value will vary from region to region.
		/// </summary>
		[JsonProperty("price_level")]
		public PriceLevel PriceLevel { get; set; }

		/// <summary>
		/// Rating contains the place's rating, from 1.0 to 5.0, based on aggregated user reviews.
		/// </summary>
		[JsonProperty("rating")]
		public float Rating { get; set; }

		/// <summary>
		/// An array of up to five reviews. If a Language parameter was specified in the Place Details request,
		/// the Places Service will bias the results to prefer reviews written in that language.
		/// </summary>
		[JsonProperty("reviews")]
		public Review[] Reviews { get; set; }

		/// <summary>
		/// Contains an array of feature types describing the given result.
		/// See the list of supported types for more information.
		/// </summary>
		/// <see href="https://developers.google.com/places/supported_types"/>
		[JsonProperty("types")]
		public PlaceType[] Types { get; set; }

		/// <summary>
		/// Contains the URL of the official Google page for this place.
		/// This will be the establishment's Google+ page if the Google+ page exists,
		/// otherwise it will be the Google-owned page that contains the best available
		/// information about the place. Applications must link to or embed this page on
		/// any screen that shows detailed results about the place to the user.
		/// </summary>
		[JsonProperty("url")]
		public string URL { get; set; }

		/// <summary>
		/// Contains the number of minutes this place’s current timezone is offset from UTC.
		/// For example, for places in Sydney, Australia during daylight saving time this would
		/// be 660 (+11 hours from UTC), and for places in California outside
		/// of daylight saving time this would be -480 (-8 hours from UTC).
		/// </summary>
		[JsonProperty("utc_offset")]
		public int UtcOffset { get; set; }

		/// <summary>
		/// lists a simplified address for the place, including the street name,
		/// street number, and locality, but not the province/state, postal code,
		/// or country. For example, Google's
		/// Sydney, Australia office has a vicinity value of 48 Pirrama Road, Pyrmont.
		/// </summary>
		[JsonProperty("vicinity")]
		public string Vicinity { get; set; }

		/// <summary>
		/// Lists the authoritative website for this place, such as a business' homepage.
		/// </summary>
		[JsonProperty("website")]
		public string Website { get; set; }
	}
}
