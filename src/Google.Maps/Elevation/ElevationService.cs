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

namespace Google.Maps.Elevation
{
	/// <summary>
	/// The Elevation service provides elevation data for all locations on the surface of the earth, including depth locations on the ocean floor (which return negative values). 
	/// In those cases where Google does not possess exact elevation measurements at the precise location you request, the service will interpolate and return an averaged value
	/// using the four nearest locations.
	/// </summary>
	/// <see cref="http://code.google.com/apis/maps/documentation/elevation/"/>
	public class ElevationService : ApiService
	{
		#region Http/Https Uris and Constructors

		public static readonly Uri HttpsUri = new Uri("https://maps.google.com/maps/api/elevation/");
		public static readonly Uri HttpUri = new Uri("http://maps.google.com/maps/api/elevation/");

		public Uri BaseUri { get; set; }

		public ElevationService() : this(HttpUri)
		{
		}
		public ElevationService(Uri baseUri)
		{
			this.BaseUri = baseUri;
		}
		#endregion

		/// <summary>
		/// Sends the specified request to the Google Maps Elevation web
		/// service and parses the response as an ElevationResponse
		/// object.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
        public ElevationResponse GetResponse(ElevationRequest request)
        {
            var httpResponse = GetHttpResponse(request);
            var geoCoderResponse = httpResponse.As<ElevationResponse>();

            if (httpResponse.FromCache && geoCoderResponse.Status != ServiceResponseStatus.Ok)
            {
                httpResponse = GetHttpResponse(request, true);
                geoCoderResponse = httpResponse.As<ElevationResponse>();
            }
            return geoCoderResponse;
        }
	}
}
