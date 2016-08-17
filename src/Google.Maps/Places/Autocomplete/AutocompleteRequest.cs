using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps.Places
{
	public class AutocompleteRequest : BaseRequest
	{
		/// <summary>
		/// Indicates whether or not the place request comes from a device
		/// with a location sensor. This value must be either true or false.
		/// </summary>
		/// <remarks>Required.</remarks>
		public bool? Sensor { get; set; }

		/// <summary>
		/// The text string on which to search. The Place Autocomplete service
		/// will return candidate matches based on this string and order
		/// results based on their perceived relevance
		/// </summary>
		public string Input { get; set; }

		/// <summary>
		/// The position, in the input term, of the last character that the
		/// service uses to match predictions
		/// </summary>
		public int Offset { get; set; }

		/// <summary>
		/// The latitude/longitude around which to retrieve Place information.
		/// </summary>
		/// <remarks>Required with RequestType=Nearby.</remarks>
		public LatLng Location { get; set; }

		/// <summary>
		/// Defines the distance (in meters) within which to bias Place results.
		/// The maximum allowed radius is 50 000 meters. Results inside of this
		/// region will be ranked higher than results outside of the search
		/// circle; however, prominent results from outside of the search radius
		/// may be included
		/// </summary>
		public int? Radius { get; set; }

		/// <summary>
		/// The language in which to return results. See the list of supported domain languages.
		/// Note that we often update supported languages so this list may not be exhaustive.
		/// </summary>
		/// <see cref="https://developers.google.com/places/documentation/search#PlaceSearchRequests"/>
		public string Language { get; set; }

		/// <summary>
		/// Restricts the results to Places matching at least one of the
		/// specified types
		/// </summary>
		/// <see cref="https://developers.google.com/places/documentation/supported_types"/>
		public PlaceType[] Types { get; set; }

		/// <summary>
		/// A grouping of places to which you would like to restrict your results
		/// </summary>
		public string Components { get; set; }

		internal override Uri ToUri()
		{
			ValidateRequest();

			var qsb = new Internal.QueryStringBuilder();

			qsb.Append("input", Input.ToLowerInvariant())
			   .Append("sensor", (Sensor.Value.ToString().ToLowerInvariant()));

			if(Offset > 0)
			{
				qsb.Append("offset", Offset.ToString());
			}

			if(Location != null)
			{
				qsb.Append("location", Location.GetAsUrlParameter());
			}

			if(Radius.HasValue)
			{
				qsb.Append("radius", (Radius.Value.ToString().ToLowerInvariant()));
			}

			if(!string.IsNullOrEmpty(Language))
			{
				qsb.Append("language", Language.ToLowerInvariant());
			}

			if((Types != null && Types.Any()))
			{
				qsb.Append("types", TypesToUri());
			}

			if(!string.IsNullOrEmpty(Components))
			{
				qsb.Append(string.Format("components=country:{0}", Components.ToLowerInvariant()));
			}

			var url = "autocomplete/json?" + qsb.ToString();
			return new Uri(url, UriKind.Relative);
		}

		protected void ValidateRequest()
		{
			if(this.Sensor == null) throw new InvalidOperationException("Sensor property hasn't been set.");

			if(string.IsNullOrEmpty(this.Input)) throw new InvalidOperationException("Input property hasn't been set.");
		}

		protected string TypesToUri()
		{
			return string.Join("|", Types.Select(t => t.ToString().ToLowerInvariant()).ToArray<string>());
		}
	}
}
