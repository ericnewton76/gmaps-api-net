using Newtonsoft.Json;

namespace Google.Maps.Places.Details
{
    public class DayTime
    {
        [JsonProperty("day")]
        public int Day { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }
    }
}