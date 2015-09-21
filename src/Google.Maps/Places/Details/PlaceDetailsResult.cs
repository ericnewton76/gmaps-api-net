using Google.Maps.Shared;
using Newtonsoft.Json;

namespace Google.Maps.Places.Details
{
    public class PlaceDetailsResult
    {
        /// <summary>
		/// Contains the ServiceResponseStatus.
		/// </summary>
		[JsonProperty("address_components")]
        public AddressComponent[] AddressComponents { get; set; }
        
        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonProperty("formatted_phone_number")]
        public string FormattedPhoneNumber { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("icon")]
        public string icon { get; set; }

        [JsonProperty("international_phone_number")]
        public string InternationalPhoneNumber { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("opening_hours")]
        public OpeningHours OpeningHours { get; set; }

        [JsonProperty("permanently_closed")]
        public bool PermanentlyClosed { get; set; }

        [JsonProperty("photos")]
        public Photo[] Photos { get; set; }

        [JsonProperty("place_id")]
        public string PlaceID { get; set; }

        [JsonProperty("scope")]
        public Scope Scope { get; set; }

        [JsonProperty("alt_ids")]
        public AltID[] AltIDs { get; set; }

        [JsonProperty("price_level")]
        public PriceLevel PriceLevel { get; set; }

        [JsonProperty("rating")]
        public float Rating { get; set; }

        [JsonProperty("reviews")]
        public Review[] Reviews { get; set; }

        [JsonProperty("types")]
        public PlaceType[] Types { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("utc_offset")]
        public int UtcOffset { get; set; }

        [JsonProperty("vicinity")]
        public string Vicinity { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }
    }
}
