using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps.Places
{
    public class RadarSearchRequest : PlacesRequest
    {
        /// <summary>
        /// A term to be matched against all content that Google has indexed 
        /// for this Place, including but not limited to name, type, and address, 
        /// as well as customer reviews and other third-party content.
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// One or more terms to be matched against the names of Places, 
        /// separated with a space character. Results will be restricted to 
        /// those containing the passed name values.
        /// </summary>
        /// <remarks>
        /// Note that a Place may have additional names associated with it, 
        /// beyond its listed name. The API will try to match the passed 
        /// name value against all of these names; as a result, Places may 
        /// be returned in the results whose listed names do not match the
        /// search term, but whose associated names do.
        /// </remarks>
        public string Name { get; set; }

        internal override Uri ToUri()
        {
            ValidateRequest();

            var qsb = new Internal.QueryStringBuilder();

            qsb.Append("location", Location.GetAsUrlParameter())
               .Append("sensor", (Sensor.Value.ToString().ToLowerInvariant()))
               .Append("radius", (Radius.Value.ToString().ToLowerInvariant()));

            if (!string.IsNullOrEmpty(Keyword))
            {
                qsb.Append("keyword", Keyword.ToString().ToLowerInvariant());
            }

            if (!string.IsNullOrEmpty(Name))
            {
                qsb.Append("name", Name.ToString().ToLowerInvariant());
            }

            if ((Types != null && Types.Any()))
            {
                qsb.Append("types", TypesToUri());
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

            var url = "radarsearch/json?" + qsb.ToString();
            return new Uri(url, UriKind.Relative);
        }

        protected override void ValidateRequest()
        {
            base.ValidateRequest();

            if (Location == null) throw new InvalidOperationException("Location property is not set");

            if (!Radius.HasValue) throw new ArgumentException("Radius property is not set.");
        }
    }
}
