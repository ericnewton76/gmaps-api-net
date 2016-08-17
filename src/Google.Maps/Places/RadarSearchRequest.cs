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
	/// The Google Places API Radar Search Service allows you to search
	/// for up to 200 Places at once, but with less detail than is typically
	/// returned from a Text Search or Nearby Search request. With Radar
	/// Search, you can create applications that help users identify specific
	/// areas of interest within a geographic area
	/// </summary>
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

			if(!string.IsNullOrEmpty(Keyword))
			{
				qsb.Append("keyword", Keyword.ToString().ToLowerInvariant());
			}

			if(Minprice.HasValue)
			{
				qsb.Append("minprice", Minprice.Value.ToString());
			}

			if(Maxprice.HasValue)
			{
				qsb.Append("maxprice", Maxprice.Value.ToString());
			}

			if(!string.IsNullOrEmpty(Name))
			{
				qsb.Append("name", Name.ToString().ToLowerInvariant());
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

			var url = "radarsearch/json?" + qsb.ToString();
			return new Uri(url, UriKind.Relative);
		}

		protected override void ValidateRequest()
		{
			base.ValidateRequest();

			if(Location == null) throw new InvalidOperationException("Location property is not set");

			if(!Radius.HasValue) throw new ArgumentException("Radius property is not set.");
		}
	}
}
