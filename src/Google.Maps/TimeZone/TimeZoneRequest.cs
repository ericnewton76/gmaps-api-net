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
using System.Web;

namespace Google.Maps.TimeZone
{
	/// <summary>
	/// Provides a request for the Google Maps Time Zone web service.
	/// </summary>
	public class TimeZoneRequest
	{
		/// <summary>
		/// The latitude and longitude co-ordinates of the location you want the time zone of.
		/// </summary>
		/// <see cref="https://developers.google.com/maps/documentation/timezone/intro?hl=en#Usage"/>
		/// <remarks>Required.</remarks>
		public LatLng Location { get; set; }

		/// <summary>
		/// Timestamp specifies the desired date and time.
		/// The Time Zone API uses the timestamp to determine whether or not Daylight Savings should be applied.
		/// </summary>
		/// <see cref="https://developers.google.com/maps/documentation/timezone/intro?hl=en#Usage"/>
		/// <remarks>Required.</remarks>
		public DateTime Timestamp { get; set; }

		/// <summary>
		/// The language in which to return results.
		/// If language is not set, the language will default to en.
		/// </summary>
		/// <remarks>Optional.</remarks>
		/// <see cref="https://developers.google.com/maps/documentation/timezone/intro?hl=en#Usage"/>
		public string Language { get; set; }

		/// <summary>
		/// Indicates whether or not the timezone request comes from a device
		/// with a location sensor. This value must be either true or false.
		/// </summary>
		/// <remarks>Required.</remarks>
		/// <see cref="https://developers.google.com/maps/documentation/timezone/intro?hl=en#Sensor"/>
		public bool? Sensor { get; set; }

		internal Uri ToUri()
		{
			EnsureSensor();
			if(Location == null) throw new InvalidOperationException("Location property is not set.");

			var qsb = new Internal.QueryStringBuilder();
			DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);

			qsb.Append("location", Location.GetAsUrlParameter())
				.Append("timestamp", (Timestamp.ToUniversalTime() - epoch).TotalSeconds.ToString())
				.Append("language", Language)
				.Append("sensor", (Sensor.Value.ToString().ToLowerInvariant()));

			var url = "json?" + qsb.ToString();

			return new Uri(url, UriKind.Relative);
		}

		private void EnsureSensor()
		{
			if(this.Sensor == null) throw new InvalidOperationException("Sensor property hasn't been set.");
		}
	}
}

