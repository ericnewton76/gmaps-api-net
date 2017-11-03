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

using Newtonsoft.Json;
using System;
using Google.Maps.Common;

namespace Google.Maps.TimeZone
{
	[JsonObject(MemberSerialization.OptIn)]
	public class TimeZoneResponse : IServiceResponse
	{
		/// <summary>
		/// Contains the ServiceResponseStatus.
		/// </summary>
		[JsonProperty("status")]
		public ServiceResponseStatus Status { get; set; }

		/// <summary>
		/// The offset for daylight-savings time in seconds. 
		/// This will be zero if the time zone is not in Daylight Savings Time during the specified timestamp.
		/// </summary>
		[JsonProperty("dstOffset")]
		public long DstOffSet { get; set; }

		/// <summary>
		/// The offset from UTC (in seconds) for the given location. This does not take into effect daylight savings.
		/// </summary>
		[JsonProperty("rawOffset")]
		public long RawOffSet { get; set; }

		/// <summary>
		/// A string containing the "tz" ID of the time zone, such as "America/Los_Angeles" or "Australia/Sydney".
		/// These IDs are defined in the IANA Time Zone Database.
		/// </summary>
		/// <see href="http://www.iana.org/time-zones"/>
		/// <see href="https://en.wikipedia.org/wiki/List_of_tz_database_time_zones"/>
		[JsonProperty("timeZoneId")]
		public string TimeZoneID { get; set; }

		/// <summary>
		/// A string containing the long form name of the time zone.
		/// This field will be localized if the language parameter is set. eg. "Pacific Daylight Time" or "Australian Eastern Daylight Time"
		/// </summary>
		[JsonProperty("timeZoneName")]
		public string TimeZoneName { get; set; }

		/// <summary>
		/// More detailed information about the reasons behind the given status code, if other than OK.
		/// </summary>
		[JsonProperty("error_message")]
		public string ErrorMessage { get; set; }
	}
}
