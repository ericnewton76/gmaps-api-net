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

namespace Google.Maps.Places.Details
{
	/// <summary>
	/// Provides a direct way to access Places Details via an HTTP request.
	/// </summary>
	public class PlaceDetailsService
	{
		#region Http/Https Uris and Constructors

		public static readonly Uri HttpsUri = new Uri("https://maps.googleapis.com/maps/api/place/details/");

		public Uri BaseUri { get; set; }

		public PlaceDetailsService()
			: this(HttpsUri)
		{
		}

		public PlaceDetailsService(Uri baseUri)
		{
			this.BaseUri = baseUri;
		}
		#endregion

		/// <summary>
		/// Sends the specified request to the Google Maps Places web
		/// service and parses the response as an PlaceDetailsResponse
		/// object.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public PlaceDetailsResponse GetResponse(PlaceDetailsRequest request)
		{
			var url = new Uri(this.BaseUri, request.ToUri());
			return Internal.Http.Get(url).As<PlaceDetailsResponse>();
		}
	}
}
