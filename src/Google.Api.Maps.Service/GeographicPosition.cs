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

namespace Google.Api.Maps.Service
{
	[JsonObject(MemberSerialization.OptIn)]
	public class GeographicPosition
	{
		/// <summary>
		/// Constructs an empty GeographicPosition
		/// </summary>
		public GeographicPosition()
		{
		}
		/// <summary>
		/// Constructs a GeographicPosition instance with latitude and longitude coordinates.
		/// </summary>
		/// <param name="latitude"></param>
		/// <param name="longitude"></param>
		public GeographicPosition(decimal latitude, decimal longitude)
		{
			this.Latitude = latitude;
			this.Longitude = longitude;
		}


		[JsonProperty("lat")]
		public decimal Latitude { get; set; }

		[JsonProperty("lng")]
		public decimal Longitude { get; set; }
	}
}
