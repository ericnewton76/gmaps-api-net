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

namespace Google.Maps.Shared
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Geometry
	{
		/// <summary>
		/// Contains the geocoded latitude,longitude value. For normal address
		/// lookups, this field is typically the most important.
		/// </summary>
		[JsonProperty("location")]
		public LatLng Location { get; set; }

		/// <summary>
		/// Stores additional data about the specified location.
		/// </summary>
		[JsonProperty("location_type")]
		public LocationType LocationType { get; set; }

		/// <summary>
		/// Contains the recommended viewport for displaying the returned
		/// result, specified as two latitude,longitude values defining the
		/// southwest and northeast corner of the viewport bounding box.
		/// Generally the viewport is used to frame a result when displaying
		/// it to a user.
		/// </summary>
		[JsonProperty("viewport")]
		public Viewport Viewport { get; set; }

		/// <summary>
		/// The precise bounds of the geocoding result, if applicable. Null if not.
		/// </summary>
		[JsonProperty("bounds")]
		public Viewport Bounds { get; set; }
	}
}
