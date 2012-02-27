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

namespace Google.Maps.Geocoding
{
	/// <summary>
	/// Provides a direct way to access a geocoder via an HTTP request.
	/// Additionally, the service allows you to perform the converse operation
	/// (turning coordinates into addresses); this process is known as
	/// "reverse geocoding."
	/// </summary>
	public static class GeocodingService
	{
		public static readonly Uri ApiUrl = 
			new Uri("http://maps.google.com/maps/api/geocode/");

		/// <summary>
		/// Sends the specified request to the Google Maps Geocoding web
		/// service and parses the response as an GeocodingResponse
		/// object.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public static GeocodingResponse GetResponse(GeocodingRequest request)
		{
			var url = new Uri(ApiUrl, request.ToUri());
			return Http.Get(url).As<GeocodingResponse>();
		}
	}
}
