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

using Google.Maps.Common;

using Newtonsoft.Json;


namespace Google.Maps.StreetView
{
	[JsonObject(MemberSerialization.OptIn)]
	public class StreetViewMetadataResponse : IServiceResponse
	{
		/// <summary>
		/// The response location
		/// </summary>
		[JsonProperty("location")]
		public LatLng Location { get; set; }

		/// <summary>
		/// The panorama id
		/// </summary>
		[JsonProperty("pano_id")]
		public string PanoId { get; set; }

		/// <inheritdoc />
		[JsonProperty("status")]
		public ServiceResponseStatus Status { get; set; }


		/// <inheritdoc />
		[JsonProperty("error_message")]
		public string ErrorMessage { get; set; }

		/// <summary>
		/// The copyright info for the image if requested
		/// </summary>
		[JsonProperty("copyright")]
		public string Copywrite { get; set; }

		/// <summary>
		/// Date photo was taken
		/// </summary>
		[JsonProperty("date")]
		public DateTime Date { get; set; }

	}
}
