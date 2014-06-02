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

namespace Google.Maps.DistanceMatrix
{
	/// <summary>
	/// The Google Distance Matrix API is a service that provides travel distance and time for a matrix of origins and destinations. The information returned is based on the recommended route 
	/// between start and end points, as calculated by the Google Maps API, and consists of rows containing duration and distance values for each pair.
	/// <para>This service does not return detailed route information. Route information can be obtained by passing the desired single origin and destination to the Directions API.</para>
	/// </summary>
	/// <see cref="http://developers.google.com/maps/documentation/distancematrix/"/>
	public class DistanceMatrixService : ApiService
	{
		#region Http/Https Uris and Constructors

		public static readonly Uri HttpsUri = new Uri("https://maps.google.com/maps/api/distancematrix/");
		public static readonly Uri HttpUri = new Uri("http://maps.google.com/maps/api/distancematrix/");

		public Uri BaseUri { get; set; }

		public DistanceMatrixService() : this(HttpUri)
		{
		}
		public DistanceMatrixService(Uri baseUri)
		{
			this.BaseUri = baseUri;
		}
		#endregion

        /// <summary>
        /// Sends the specified request to the Google Maps DistanceMatrix web
        /// service and parses the response as an DistanceMatrixResponse
        /// object.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 
        public DistanceMatrixResponse GetResponse(DistanceMatrixRequest request)
        {
            var httpResponse = GetHttpResponse(request);
            var geoCoderResponse = httpResponse.As<DistanceMatrixResponse>();

            if (httpResponse.FromCache && geoCoderResponse.Status != ServiceResponseStatus.Ok)
            {
                httpResponse = GetHttpResponse(request, true);
                geoCoderResponse = httpResponse.As<DistanceMatrixResponse>();
            }
            return geoCoderResponse;
        }
	}
}
