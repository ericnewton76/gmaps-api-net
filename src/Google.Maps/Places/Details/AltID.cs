using Newtonsoft.Json;

namespace Google.Maps.Places.Details
{
    public class AltID
    {
        [JsonProperty("place_id")]
        public string PlaceID { get; set; }

        [JsonProperty("scope")]
        public Scope Scope { get; set; }
    }
}