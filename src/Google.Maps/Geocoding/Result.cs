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

using Newtonsoft.Json;
using System;

namespace Google.Maps.Geocoding
{
	[Serializable]
	[JsonObject(MemberSerialization.OptIn)]
	public class Result
	{
		/// <summary>
		/// Indicates the type of the returned result. This array contains a
		/// set of one or more tags identifying the type of feature returned
		/// in the result. For example, a geocode of "Chicago" returns
		/// "locality" which indicates that "Chicago" is a city, and also
		/// returns "political" which indicates it is a political entity.
		/// </summary>
		[JsonProperty("types")]
		public AddressType[] Types { get; set; }

		/// <summary>
		/// A string containing the human-readable address of this location.
		/// Often this address is equivalent to the "postal address," which
		/// sometimes differs from country to country. (Note that some
		/// countries, such as the United Kingdom, do not allow distribution
		/// of true postal addresses due to licensing restrictions.) This
		/// address is generally composed of one or more address components.
		/// </summary>
		[JsonProperty("formatted_address")]
		public string FormattedAddress { get; set; }

		/// <summary>
		/// An array containing the separate address components.  For example,
		/// the address "111 8th Avenue, New York, NY" contains separate
		/// address components for "111" (the street number, "8th Avenue" (the
		/// route), "New York" (the city) and "NY" (the US state).
		/// </summary>
		[JsonProperty("address_components")]
		public AddressComponent[] AddressComponents { get; set; }

		[JsonProperty("geometry")]
		public Geometry Geometry { get; set; }
	}
}
