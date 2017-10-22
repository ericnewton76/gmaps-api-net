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
using System.Globalization;

namespace Google.Maps
{
	[JsonObject(MemberSerialization.OptIn)]
	public class ViaLatLng : Location, IEquatable<ViaLatLng>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ViaLatLng" /> class.
		/// </summary>
		public ViaLatLng()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ViaLatLng" /> class with the given latitude and longitude coordinates.
		/// </summary>
		/// <param name="latitude">Latitude coordinates.</param>
		/// <param name="longitude">Longitude coordinates.</param>
		public ViaLatLng(decimal latitude, decimal longitude)
		{
			this._latitude = Convert.ToDouble(latitude);
			this._longitude = Convert.ToDouble(longitude);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ViaLatLng" /> class with the given latitude and longitude coordinates.
		/// </summary>
		/// <param name="latitude">Latitude coordinates.</param>
		/// <param name="longitude">Longitude coordinates.</param>
		public ViaLatLng(double latitude, double longitude)
		{
			this._latitude = latitude;
			this._longitude = longitude;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ViaLatLng" /> class with the given latitude and longitude coordinates.
		/// </summary>
		/// <param name="latitude">Latitude coordinates.</param>
		/// <param name="longitude">Longitude coordinates.</param>
		public ViaLatLng(float latitude, float longitude)
		{
			this._latitude = Convert.ToDouble(latitude);
			this._longitude = Convert.ToDouble(longitude);
		}

		private double _latitude;
		private double _longitude;

		/// <summary>
		/// Gets the latitude coordinate.
		/// </summary>
		[JsonProperty("lat")]
		public double Latitude
		{
			get { return _latitude; }
		}

		/// <summary>
		/// Gets the longitude coordinate.
		/// </summary>
		[JsonProperty("lng")]
		public double Longitude
		{
			get { return _longitude; }
		}

		/// <summary>
		/// Gets the string representation of the latitude and longitude coordinates. Default format is "N6" for 6 decimal precision.
		/// </summary>
		/// <returns>Latitude and longitude coordinates.</returns>
		public override string ToString()
		{
			return this.ToString("N6");
		}

		/// <summary>
		/// Gets the string representation of the latitude and longitude coordinates. The format is applies to a System.Double, so any format applicable for System.Double will work.
		/// </summary>
		/// <param name="format"></param>
		/// <returns></returns>
		public string ToString(string format)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder(50); //default to 50 in the internal array.
			sb.Append("via:");
			sb.Append(this.Latitude.ToString(format, System.Globalization.CultureInfo.InvariantCulture));
			sb.Append(",");
			sb.Append(this.Longitude.ToString(format, System.Globalization.CultureInfo.InvariantCulture));

			return sb.ToString();
		}

		/// <summary>
		/// Gets the current instance as a URL encoded value.
		/// </summary>
		/// <returns></returns>
		public override string GetAsUrlParameter()
		{
			//we're not returning crazy characters so just return the string.
			//prevents the comma from being converted to %2c, expanding the single character to three characters.
			return this.ToString("R");
		}

		/// <summary>
		/// Parses a ViaLatLng from a set of latitude/longitude coordinates
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static ViaLatLng Parse(string value)
		{
			if(value == null) throw new ArgumentNullException("value");

			try
			{
				string[] parts = value.Split(',');

				if(parts.Length != 2) throw new FormatException("Missing data for points.");

				double latitude = double.Parse(parts[0].Trim(), CultureInfo.InvariantCulture);
				double longitude = double.Parse(parts[1].Trim(), CultureInfo.InvariantCulture);

				ViaLatLng vialatlng = new ViaLatLng(latitude, longitude);

				return vialatlng;
			}
			catch(Exception ex)
			{
				throw new FormatException("Failed to parse ViaLatLng.", ex);
			}
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as ViaLatLng);
		}

		public bool Equals(ViaLatLng other)
		{
			if(other == null)
			{
				return false;
			}

			if(other.Latitude == this.Latitude && other.Longitude == this.Longitude)
			{
				return true;
			}

			return false;
		}

		public override int GetHashCode()
		{
			int hash = 13;
			hash += (hash * 7) + this.Latitude.GetHashCode();
			hash += (hash * 7) + this.Longitude.GetHashCode();
			return hash;
		}
	}
}
