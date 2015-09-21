using Newtonsoft.Json;

namespace Google.Maps.Places.Details
{
    public class Photo
    {
        [JsonProperty("photo_reference")]
        public string PhotoReference { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("html_attributions")]
        public string[] HtmlAttributions { get; set; }
    }
}