using Newtonsoft.Json;

namespace Google.Maps.Places.Details
{
    public class AspectRating
    {
        [JsonProperty("type")]
        public AspectType Type { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }
    }
}