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

namespace Google.Maps
{
	public enum ServiceResponseStatus
	{
		Unknown = 0,

		/// <summary>
		/// Indicates that no errors occurred; the address was successfully 
		/// parsed and at least one geocode was returned.
		/// </summary>
		Ok = -1,

		/// <summary>
		/// Indicating the service request was malformed.
		/// </summary>
		InvalidRequest = 1,

		/// <summary>
		/// Indicates that the geocode was successful but returned no results.
		/// This may occur if the geocode was passed a non-existent address or
		/// a latlng in a remote location.
		/// </summary>
		ZeroResults = 2,

		/// <summary>
		/// Indicates that you are over your quota.
		/// </summary>
		OverQueryLimit = 3,

		/// <summary>
		/// Indicates that your request was denied, generally because of lack
		/// of a sensor parameter.
		/// </summary>
		RequestDenied = 4
	}
}
