using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Google.Api.Maps.Service.Direction
{
    [JsonObject(MemberSerialization.OptIn)]
    public class DirectionStep
    {
        [JsonProperty("travel_mode")]
        public TravelMode TravelMode { get; set; }

        [JsonProperty("start_location")]
        public GeographicPosition StartLocation { get; set; }

        [JsonProperty("end_location")]
        public GeographicPosition EndLocation { get; set; }

        [JsonProperty("polyline")]
        public Polyline Polyline { get; set; }

        [JsonProperty("duration")]
        public ValueText Duration { get; set; }

        [JsonProperty("html_instructions")]
        public string HtmlInstructions { get; set; }

        [JsonProperty("distance")]
        public ValueText Distance { get; set; }

        public DirectionStep() { }

        public DirectionStep(GeographicPosition start, GeographicPosition end)
        {
            StartLocation = start;
            EndLocation = end;
        }

        public DirectionStep(decimal startLat, decimal startLng, decimal endLat, decimal endLng)
        {
            StartLocation = new GeographicPosition(startLat, startLng);
            EndLocation = new GeographicPosition(endLat, endLng);
        }
    }
}
