using Google.Maps.Geocoding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps.Places
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class PlacesResult
    {
        /// <summary>
        /// Indicates the type of the returned result. This array contains a
        /// set of one or more tags identifying the type of feature returned
        /// in the result. For example, a geocode of "Chicago" returns
        /// "locality" which indicates that "Chicago" is a city, and also
        /// returns "political" which indicates it is a political entity.
        /// </summary>
        [JsonProperty("types")]
        public PlaceType[] Types { get; set; }

        /// <summary>
        /// A string containing the human-readable address of this location.
        /// Often this address is equivalent to the "postal address," which
        /// sometimes differs from country to country. (Note that some
        /// countries, such as the United Kingdom, do not allow distribution
        /// of true postal addresses due to licensing restrictions.) This
        /// address is generally composed of one or more address components.
        /// </summary>
        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
