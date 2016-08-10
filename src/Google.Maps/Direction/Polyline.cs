using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Google.Maps.Direction
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Polyline
    {
        [JsonProperty("points")]
        public string Points { get; set; }

        [JsonProperty("levels")]
        public string Levels { get; set; }

        /**
         * Decodes an encoded path string into a sequence of LatLngs.
         */
        public List<LatLng> Decode()
        {

            int len = Points.Length;

            List<LatLng> path = new List<LatLng>(len / 2);
            int index = 0;
            int lat = 0;
            int lng = 0;

            while (index < len)
            {
                int result = 1;
                int shift = 0;
                int b;
                do
                {
                    b = Points[index++] - 63 - 1;
                    result += b << shift;
                    shift += 5;
                } while (b >= 0x1f);
                lat += (result & 1) != 0 ? ~(result >> 1) : (result >> 1);

                result = 1;
                shift = 0;
                do
                {
                    b = Points[index++] - 63 - 1;
                    result += b << shift;
                    shift += 5;
                } while (b >= 0x1f);
                lng += (result & 1) != 0 ? ~(result >> 1) : (result >> 1);

                path.Add(new LatLng(lat * 1e-5, lng * 1e-5));
            }

            return path;
        }
    }
}
