using Newtonsoft.Json;

namespace Google.Maps.Places.Details
{
    public class Review
    {
        [JsonProperty("aspects")]
        public AspectRating[] Aspects { get; set; }

        [JsonProperty("author_name")]
        public string AuthorName { get; set; }

        [JsonProperty("author_url")]
        public string AuthorURL { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("rating")]
        public int rating { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }
    }
}