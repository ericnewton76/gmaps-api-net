using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Google.Api.Maps.Service.Direction
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ValueText
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
