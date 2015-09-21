using Newtonsoft.Json;

namespace Google.Maps.Places.Details
{
    public class Period
    {
        [JsonProperty("open")]
        public DayTime Open { get; set; }

        [JsonProperty("close")]
        public DayTime Close { get; set; }
    }
}