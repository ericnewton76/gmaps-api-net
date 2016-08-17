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
	public abstract class PlacesRequest : BaseRequest
	{
		/// <summary>
		/// Indicates whether or not the place request comes from a device
		/// with a location sensor. This value must be either true or false.
		/// </summary>
		/// <remarks>Required.</remarks>
		public bool? Sensor { get; set; }

		/// <summary>
		/// The latitude/longitude around which to retrieve Place information.
		/// </summary>
		/// <remarks>Required with RequestType=Nearby.</remarks>
		public LatLng Location { get; set; }

		/// <summary>
		/// Restricts results to only those places within the specified range.
		/// Valid values range between 0 (most affordable) to 4 (most expensive),
		/// inclusive. The exact amount indicated by a specific value will vary
		/// from region to region.
		/// </summary>
		public int? Minprice { get; set; }

		/// <summary>
		/// Restricts results to only those places within the specified range.
		/// Valid values range between 0 (most affordable) to 4 (most expensive),
		/// inclusive. The exact amount indicated by a specific value will vary
		/// from region to region.
		/// </summary>
		public int? Maxprice { get; set; }

		/// <summary>
		/// Returns only those Places that are open for business at the
		/// time the query is sent. Places that do not specify opening
		/// hours in the Google Places database will not be returned if
		/// you include this parameter in your query.
		/// </summary>
		public bool? OpenNow { get; set; }

		/// <summary>
		/// Restricts the results to Places matching at least one of the
		/// specified types
		/// </summary>
		/// <see cref="https://developers.google.com/places/documentation/supported_types"/>
		public PlaceType[] Types { get; set; }

		/// <summary>
		/// Add this parameter to restrict your search to locations that are
		/// Zagat selected businesses.
		/// </summary>
		/// <remarks>
		/// This parameter is experimental, and is only available to Places
		/// API enterprise customers.
		/// </remarks>
		public bool ZagatSelected { get; set; }

		/// <summary>
		/// Defines the distance (in meters) within which to bias Place results.
		/// The maximum allowed radius is 50 000 meters. Results inside of this
		/// region will be ranked higher than results outside of the search
		/// circle; however, prominent results from outside of the search radius
		/// may be included
		/// </summary>
		public int? Radius { get; set; }

		protected virtual void ValidateRequest()
		{
			if(this.Sensor == null) throw new InvalidOperationException("Sensor property hasn't been set.");

			if(this.Minprice.HasValue && (this.Minprice < 0 || this.Minprice > 4)) throw new ArgumentException("Minprice property must have a value between 0 and 4 inclusive.");

			if(this.Maxprice.HasValue && (this.Maxprice < 0 || this.Maxprice > 4)) throw new ArgumentException("Maxprice property must have a value between 0 and 4 inclusive.");

			if(Radius.HasValue && Radius.Value > 50000)
			{
				throw new InvalidOperationException("Radius property cannot be bigger than 50 000.");
			}
		}

		protected string TypesToUri()
		{
			return string.Join("|", Types.Select(t => t.ToString().ToLowerInvariant()).ToArray<string>());
		}
	}
}
