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
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Google.Maps.TimeZone
{
	/// <summary>
	/// Provides a direct way to access a time zone service via an HTTP request.
	/// </summary>
	public class TimeZoneService
	{
		#region Http/Https Uris and Constructors

		public static readonly Uri HttpsUri = new Uri("https://maps.googleapis.com/maps/api/timezone/outputFormat?parameters");

		public Uri BaseUri { get; set; }

		public TimeZoneService()
			: this(HttpsUri)
		{
		}

		public TimeZoneService(Uri baseUri)
		{
			this.BaseUri = baseUri;
		}
		#endregion

		/// <summary>
		/// Sends the specified request to the Google Maps Time Zone web
		/// service and parses the response as an TimeZoneResponse
		/// object.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public TimeZoneResponse GetResponse(TimeZoneRequest request)
		{
			var url = new Uri(this.BaseUri, request.ToUri());
			return Internal.Http.Get(url).As<TimeZoneResponse>();
		}
	}
}
