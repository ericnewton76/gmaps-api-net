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
using System.Threading.Tasks;

using Google.Maps.Internal;

namespace Google.Maps.Geocoding
{
	/// <summary>
	/// Provides a direct way to access a geocoder via an HTTP request.
	/// Additionally, the service allows you to perform the converse operation
	/// (turning coordinates into addresses); this process is known as
	/// "reverse geocoding."
	/// </summary>
	public class GeocodingService : IDisposable
	{
		public static readonly Uri HttpsUri = new Uri("https://maps.google.com/maps/api/geocode/");
		public static readonly Uri HttpUri = new Uri("http://maps.google.com/maps/api/geocode/");

		Uri baseUri;
		MapsHttp http;

		public GeocodingService(GoogleSigned signingSvc = null, Uri baseUri = null)
		{
			this.baseUri = baseUri ?? HttpsUri;

			this.http = new MapsHttp(signingSvc ?? GoogleSigned.SigningInstance);
		}

		/// <summary>
		/// Sends the specified request to the Google Maps Geocoding web
		/// service and parses the response as an GeocodingResponse
		/// object.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public GeocodeResponse GetResponse(GeocodingRequest request)
		{
			var url = new Uri(baseUri, request.ToUri());

			return http.Get<GeocodeResponse>(url);
		}

		public async Task<GeocodeResponse> GetResponseAsync(GeocodingRequest request)
		{
			var url = new Uri(baseUri, request.ToUri());

			return await http.GetAsync<GeocodeResponse>(url);
		}

		public void Dispose()
		{
			if (http != null)
			{
				http.Dispose();
				http = null;
			}
		}
	}
}
