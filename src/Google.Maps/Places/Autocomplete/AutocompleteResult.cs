using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps.Places
{
	/// <summary>
	/// 
	/// </summary>
	public class AutocompleteResult
	{
		/// <summary>
		/// Contains a unique stable identifier denoting this place. 
		/// This identifier may not be used to retrieve information 
		/// about this place, but can be used to consolidate data about
		/// this place, and to verify the identity of a place across 
		/// separate searches
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// Contains the human-readable name for the returned result. 
		/// For establishment results, this is usually the business name
		/// </summary>
		[JsonProperty("description")]
		public string description { get; set; }

		/// <summary>
		/// Is a textual identifier that uniquely identifies a place.
		/// To retrieve information about the place, pass this identifier 
		/// in the placeId field of a Google Places API Web Service request.
		/// </summary>
		[JsonProperty("place_id")]
		public string PlaceId { get; set; }

		/// <summary>
		/// Contains a unique token that you can use to retrieve additional
		/// information about this place in a Place Details request. You
		/// can store this token and use it at any time in future to refresh
		/// cached data about this place, but the same token is not 
		/// guaranteed to be returned for any given place across different
		/// searches
		/// </summary>
		[JsonProperty("reference")]
		public string Reference { get; set; }

		/// <summary>
		/// Contains an array of terms identifying each section of the
		/// returned description (a section of the description is generally
		/// terminated with a comma). Each entry in the array has a value
		/// field, containing the text of the term, and an offset field,
		/// defining the start position of this term in the description,
		/// measured in Unicode characters
		/// </summary>
		[JsonProperty("terms")]
		public AutocompleteTerm[] Terms { get; set; }

		/// <summary>
		/// Contains an array of types that apply to this place.
		/// </summary>
		/// <remarks>For example: [ "political", "locality" ] or [ "establishment", "geocode" ].</remarks>
		[JsonProperty("types")]
		public PlaceType[] Types { get; set; }

		/// <summary>
		/// These describe the location of the entered term in the prediction result text, so that the term can be highlighted if desired
		/// </summary>
		[JsonProperty("matched_substrings")]
		public SubstringMatch[] MatchedSubstrings { get; set; }
	}

	public class AutocompleteTerm
	{
		[JsonProperty("value")]
		public string Value { get; set; }
		[JsonProperty("offset")]
		public int Offset { get; set; }
	}

	public class SubstringMatch
	{
		[JsonProperty("length")]
		public int Length { get; set; }
		[JsonProperty("offset")]
		public int Offset { get; set; }
	}
}
