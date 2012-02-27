using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Google.Api.Maps.Service.Direction
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Polyline
    {
        [JsonProperty("points")]
        public string Points { get; set; }

        [JsonProperty("levels")]
        public string Levels { get; set; }
    }
}
