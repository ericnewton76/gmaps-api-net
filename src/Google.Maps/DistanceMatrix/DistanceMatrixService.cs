﻿/*
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
	/// <see href="http://developers.google.com/maps/documentation/distancematrix/"/>
	public class DistanceMatrixService
	{
		//if you plan to use apiKey Google forces you to use https. Also it is ok to use https without apiKey.
		public static readonly Uri HttpsUri = new Uri("https://maps.google.com/maps/api/distancematrix/");
		//public static readonly Uri HttpUri = new Uri("http://maps.google.com/maps/api/distancematrix/");

		public Uri BaseUri { get; set; }

		public DistanceMatrixService()
			: this(HttpsUri)
		{
		}

		public DistanceMatrixService(Uri baseUri)
		{
			this.BaseUri = baseUri;
		}

		public DistanceMatrixResponse GetResponse(DistanceMatrixRequest request)
		{
			var url = new Uri(this.BaseUri, request.ToUri());
			return Internal.Http.Get(url).As<DistanceMatrixResponse>();
		}
	}
}
