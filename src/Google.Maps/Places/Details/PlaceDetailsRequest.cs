using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps.Places.Details
{
	public class PlaceDetailsRequest : BaseRequest
	{
		/// <summary>
		/// Undocumented address component filters.
		/// Only geocoding results matching the component filters will be returned.
		/// </summary>
		/// <remarks>IE: country:uk|locality:stathern</remarks>
		public string PlaceID { get; set; }

		/// <summary>
		/// The bounding box of the viewport within which to bias geocode
		/// results more prominently.
		/// </summary>
		/// <remarks>
		/// Optional. This parameter will only influence, not fully restrict, results
		/// from the geocoder.
		/// </remarks>
		/// <see href="http://code.google.com/apis/maps/documentation/geocoding/#Viewports"/>
		[System.Obsolete("Use PlaceID")]
		public string Reference { get; set; }

		/// <summary>
		/// The region code, specified as a ccTLD ("top-level domain")
		/// two-character value.
		/// </summary>
		/// <remarks>
		/// Optional. This parameter will only influence, not fully restrict, results
		/// from the geocoder.
		/// </remarks>
		/// <see href="http://code.google.com/apis/maps/documentation/geocoding/#RegionCodes"/>
		public string Extensions { get; set; }

        /// <summary>
        /// Use the fields parameter to specify a comma-separated list of place data types to return
        /// </summary>
        /// <remarks>
        /// Optional.
        /// </remarks>
        /// <see href="https://developers.google.com/places/web-service/details#fields" />
        public string[] Fields { get; set; }

		/// <summary>
		/// A random string which identifies an autocomplete session for billing purposes. Use this for Place Details requests that are called following an autocomplete request in the same user session.
		/// </summary>
		/// <remarks>
		/// Optional.
		/// </remarks>
		/// <see href="https://developers.google.com/places/web-service/details" />
		public string SessionToken { get; set; }

		/// <summary>
		/// The language in which to return results. If language is not
		/// supplied, the geocoder will attempt to use the native language of
		/// the domain from which the request is sent wherever possible.
		/// </summary>
		/// <remarks>Optional.</remarks>
		/// <see href="http://code.google.com/apis/maps/faq.html#languagesupport"/>
		public string Language { get; set; }

		public override Uri ToUri()
		{
			var qsb = new Internal.QueryStringBuilder();

			if(!String.IsNullOrEmpty(PlaceID))
			{
				qsb.Append("placeid", PlaceID);
			}
#pragma warning disable CS0618 // Type or member is obsolete
			else if(!String.IsNullOrEmpty(Reference))
			{
				qsb.Append("reference", Reference);
			}
#pragma warning restore CS0618 // Type or member is obsolete
			else
			{
				throw new InvalidOperationException("Either PlaceID or Reference fields must be set.");
			}

			if(!String.IsNullOrEmpty(Extensions))
				qsb.Append("extensions", Extensions);

            if ((Fields != null && Fields.Any()))
            {
                qsb.Append("fields", string.Join("|", Fields));
            }

			if(!String.IsNullOrEmpty(Language))
				qsb.Append("language", Language);

			if(!string.IsNullOrEmpty(SessionToken))
				qsb.Append("sessiontoken", SessionToken);

			var url = "json?" + qsb.ToString();

			return new Uri(url, UriKind.Relative);
		}
	}
}
