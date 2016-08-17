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
	/// The Google Places API Text Search Service is a web service that
	/// returns information about a set of Places based on a string
	/// </summary>
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

			qsb.Append("query", Uri.EscapeDataString(Query.ToLowerInvariant()))
			   .Append("sensor", (Sensor.Value.ToString().ToLowerInvariant()));

			if(Location != null)
			{
				qsb.Append("location", Location.GetAsUrlParameter());
			}

			if(Radius.HasValue)
			{
				qsb.Append("radius", Radius.Value.ToString());
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

			if((Types != null && Types.Any()))
			{
				qsb.Append("types", TypesToUri());
			}

			if(ZagatSelected)
			{
				qsb.Append("zagatselected");
			}

			var url = "textsearch/json?" + qsb.ToString();

			return new Uri(url, UriKind.Relative);
		}

		protected override void ValidateRequest()
		{
			base.ValidateRequest();

			if(string.IsNullOrEmpty(Query)) throw new InvalidOperationException("Query property is not set");
		}
	}
}
