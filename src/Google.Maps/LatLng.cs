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

namespace Google.Maps
{
	[JsonObject(MemberSerialization.OptIn)]
	public class LatLng : Location
	{
		public LatLng()
		{
		}
		/// <summary>
		/// Create a new latlng instance with the given latitude and longitude coordinates.
		/// </summary>
		/// <param name="latitude"></param>
		/// <param name="longitude"></param>
		public LatLng(decimal latitude, decimal longitude)
		{
			this.Latitude = latitude;
			this.Longitude = longitude;
		}
		/// <summary>
		/// Create a new latlng instance with the given latitude and longitude coordinates.
		/// </summary>
		/// <param name="latitude"></param>
		/// <param name="longitude"></param>
		public LatLng(double latitude, double longitude)
		{
			this.Latitude = Convert.ToDecimal(latitude);
			this.Longitude = Convert.ToDecimal(longitude);
		}
		/// <summary>
		/// Create a new latlng instance with the given latitude and longitude coordinates.
		/// </summary>
		/// <param name="latitude"></param>
		/// <param name="longitude"></param>
		public LatLng(float latitude, float longitude)
		{
			this.Latitude = Convert.ToDecimal(latitude);
			this.Longitude = Convert.ToDecimal(longitude);
		}

		/// <summary>
		/// Gets or sets the latitude coordinate
		/// </summary>
		[JsonProperty("lat")]
		public decimal Latitude { get; set; }

		/// <summary>
		/// Gets or sets the longitude coordinate
		/// </summary>
		[JsonProperty("lng")]
		public decimal Longitude { get; set; }

		/// <summary>
		/// Gets the string representation of the latitude and longitude coordinates.  Decimals set to 6 places.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format(
				System.Globalization.CultureInfo.InvariantCulture, //google uses en-US standard for the maps api currently.
				"{0:0.000000},{1:0.000000}", this.Latitude, this.Longitude);
		}

		/// <summary>
		/// Gets the current instance as a URL encoded value.
		/// </summary>
		/// <returns></returns>
		public override string GetAsUrlParameter()
		{
			//we're not returning crazy characters so just return the string.  
			//prevents the comma from being converted to %2c, expanding the single character to three characters.
			return this.ToString();
		}

		#region Parse

		/// <summary>
		/// Parses a LatLng from a set of latitude/longitude coordinates
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static LatLng Parse(string value)
		{
			if (value == null) throw new ArgumentNullException("value");

			try
			{
				string[] parts = value.Split(',');

				if (parts.Length != 2) throw new FormatException("Missing data for points.");

				decimal latitude = decimal.Parse(parts[0].Trim());
				decimal longitude = decimal.Parse(parts[1].Trim());

				LatLng latlng = new LatLng(latitude, longitude);

				return latlng;
			}
			catch (Exception ex)
			{
				throw new FormatException("Failed to parse LatLng.", ex);
			}
		}
		#endregion
	}
}
