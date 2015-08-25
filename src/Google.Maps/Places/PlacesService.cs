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

namespace Google.Maps.Places
{
	/// <summary>
	/// The Google Places API allows you to query for place information 
	/// on a variety of categories, such as: establishments, prominent 
	/// points of interest, geographic locations, and more. You can search 
	/// for places either by proximity or a text string.
	/// </summary>
	public class PlacesService
	{
		#region Http/Https Uris and Constructors

		public static readonly Uri HttpsUri = new Uri("https://maps.googleapis.com/maps/api/place/");
		public static readonly Uri HttpUri = new Uri("http://maps.googleapis.com/maps/api/place/");

		public Uri BaseUri { get; set; }

		public PlacesService()
			: this(HttpsUri)
		{
		}

		public PlacesService(Uri baseUri)
		{
			this.BaseUri = baseUri;
		}
		#endregion

		/// <summary>
		/// Sends the specified request to the Google Maps Geocoding web
		/// service and parses the response as an GeocodingResponse
		/// object.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public PlacesResponse GetResponse<TRequest>(TRequest request) where TRequest : PlacesRequest
		{
			var url = new Uri(this.BaseUri, request.ToUri());
			return Internal.Http.Get(url).As<PlacesResponse>();
		}

		/// <summary>
		/// Sends the specified request to the Google Maps Places Autocomplate web
		/// service and parses the response as an AutocompleteResponse
		/// object.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public AutocompleteResponse GetAutocompleteResponse(AutocompleteRequest request)
		{
			var url = new Uri(this.BaseUri, request.ToUri());
			return Internal.Http.Get(url).As<AutocompleteResponse>();
		}
	}
}
