/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Linq;

namespace Google.Maps.Places
{
	/// <summary>
	/// A Nearby Search lets you search for Places within a specified area.
	/// You can refine your search request by supplying keywords or
	/// specifying the type of Place you are searching for
	/// </summary>
	public class NearbySearchRequest : PlacesRequest
	{
		/// <summary>
		/// A term to be matched against all content that Google has indexed
		/// for this Place, including but not limited to name, type, and address,
		/// as well as customer reviews and other third-party content.
		/// </summary>
		public string Keyword { get; set; }

		/// <summary>
		/// The language in which to return results. See the list of supported domain languages.
		/// Note that we often update supported languages so this list may not be exhaustive.
		/// </summary>
		/// <see cref="https://developers.google.com/places/documentation/search#PlaceSearchRequests"/>
		public string Language { get; set; }

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

		/// <summary>
		/// Specifies the order in which results are listed.
		/// </summary>
		/// <remarks>Only supported by the Neerby search.</remarks>
		public RankBy? RankBy { get; set; }

		/// <summary>
		/// Returns the next 20 results from a previously run
		/// search. Setting a pagetoken parameter will execute
		/// a search with the same parameters used previously
		/// — all parameters other than pagetoken will be ignored.
		/// </summary>
		public string PageToken { get; set; }

		internal override Uri ToUri()
		{
			ValidateRequest();

			var qsb = new Internal.QueryStringBuilder();

			qsb.Append("location", Location.GetAsUrlParameter())
			   .Append("sensor", (Sensor.Value.ToString().ToLowerInvariant()));

			if(RankBy.GetValueOrDefault(Maps.RankBy.Prominence) != Maps.RankBy.Distance)
			{
				// Note that radius must not be included if rankby=distance
				qsb.Append("radius", Radius.ToString());
			}
			else
			{
				qsb.Append("rankby", RankBy.Value.ToString().ToLowerInvariant());
			}

			if(!string.IsNullOrEmpty(Keyword))
			{
				qsb.Append("keyword", Keyword.ToString().ToLowerInvariant());
			}

			if(!string.IsNullOrEmpty(Name))
			{
				qsb.Append("name", Name.ToString().ToLowerInvariant());
			}

			if((Types != null && Types.Any()))
			{
				qsb.Append("types", TypesToUri());
			}

			if(!string.IsNullOrEmpty(Language))
			{
				qsb.Append("language", Language.ToLowerInvariant());
			}

			if(Minprice.HasValue)
			{
				qsb.Append("minprice", Minprice.Value.ToString());
			}

			if(Maxprice.HasValue)
			{
				qsb.Append("maxprice", Maxprice.Value.ToString());
			}

			if(OpenNow.HasValue)
			{
				qsb.Append("opennow", OpenNow.Value.ToString().ToLowerInvariant());
			}

			if(!string.IsNullOrEmpty(PageToken))
			{
				qsb.Append("pagetoken", PageToken);
			}

			if(ZagatSelected)
			{
				qsb.Append("zagatselected");
			}

			var url = "nearbysearch/json?" + qsb.ToString();
			return new Uri(url, UriKind.Relative);
		}

		protected override void ValidateRequest()
		{
			base.ValidateRequest();

			if(Location == null) throw new InvalidOperationException("Location property is not set");

			if(RankBy != null && RankBy != Maps.RankBy.Distance)
			{
				if(!Radius.HasValue) throw new ArgumentException("Radius property is not set.");
			}
			else if(RankBy != null && RankBy == Maps.RankBy.Distance)
			{
				if(string.IsNullOrEmpty(Keyword) && string.IsNullOrEmpty(Name) && (Types == null || !Types.Any()))
				{
					throw new ArgumentException("Atleast one of Keyword, Name or Types must be supplied.");
				}
			}
		}
	}
}
