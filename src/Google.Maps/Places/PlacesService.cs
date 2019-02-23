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
using Google.ApiCore;

namespace Google.Maps.Places
{
	/// <summary>
	/// The Google Places API allows you to query for place information 
	/// on a variety of categories, such as: establishments, prominent 
	/// points of interest, geographic locations, and more. You can search 
	/// for places either by proximity or a text string.
	/// </summary>
	public class PlacesService : ApiCore.BaseGmapsServiceTypedResponse<PlacesRequest, PlacesResponse>
	{
		public static readonly Uri HttpsUri = new Uri("https://maps.googleapis.com/maps/api/place/");

		Uri baseUri;
		MapsHttp http;

		public PlacesService(IHttpService httpService, Uri baseUri)
		{
			this.HttpService = httpService;
			this.BaseUri = (baseUri != null ? baseUri : HttpsUri);
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
			var url = new Uri(baseUri, request.ToUri());

			return http.Get<AutocompleteResponse>(url);
		}

		public async Task<AutocompleteResponse> GetAutocompleteResponseAsync(AutocompleteRequest request)
		{
			var url = new Uri(baseUri, request.ToUri());

			return await http.GetAsync<AutocompleteResponse>(url);
		}

	}
}
