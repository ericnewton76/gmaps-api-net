using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps.Places
{
    public class TextSearchRequest : PlacesRequest
    {
        public string Query { get; set; }

        /// <summary>
        /// The language in which to return results. See the list of supported domain languages. 
        /// Note that we often update supported languages so this list may not be exhaustive.
        /// </summary>
        /// <see cref="https://developers.google.com/places/documentation/search#PlaceSearchRequests"/>
        public string Language { get; set; }

        internal override Uri ToUri()
        {
            ValidateRequest();
            var qsb = new Internal.QueryStringBuilder();

            qsb.Append("query", Query.ToLowerInvariant())
               .Append("sensor", (Sensor.Value.ToString().ToLowerInvariant()));

            if (Radius.HasValue)
            {
                qsb.Append("radius", Radius.Value.ToString());
            }

            if (!string.IsNullOrEmpty(Language))
            {
                qsb.Append("language", Language.ToLowerInvariant());
            }

            if (Minprice.HasValue)
            {
                qsb.Append("minprice", Minprice.Value.ToString());
            }

            if (Maxprice.HasValue)
            {
                qsb.Append("maxprice", Maxprice.Value.ToString());
            }

            if (OpenNow.HasValue)
            {
                qsb.Append("opennow", OpenNow.Value.ToString().ToLowerInvariant());
            }

            if (ZagatSelected)
            {
                qsb.Append("zagatselected");
            }

            var url = "textsearch/json?" + qsb.ToString();

            return new Uri(url, UriKind.Relative);
        }

        protected override void ValidateRequest()
        {
            base.ValidateRequest();

            if (string.IsNullOrEmpty(Query)) throw new InvalidOperationException("Query property is not set");
        }
    }
}
