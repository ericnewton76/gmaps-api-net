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

namespace Google.Maps.Shared
{
	public enum LocationType
	{
		/// <summary>
		/// Unknown
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// Indicates that the returned result is a precise geocode for which we have
		/// location information accurate down to street address precision.
		/// </summary>
		Rooftop = 1,

		/// <summary>
		/// Indicates that the returned result reflects an approximation (usually on
		/// a road) interpolated between two precise points (such as intersections).
		/// Interpolated results are generally returned when rooftop geocodes are
		/// unavailable for a street address.
		/// </summary>
		RangeInterpolated = 2,

		/// <summary>
		/// Indicates that the returned result is the geometric center of a result
		/// such as a polyline (for example, a street) or polygon (region).
		/// </summary>
		GeometricCenter = 3,

		/// <summary>
		/// Indicates that the returned result is approximate.
		/// </summary>
		Approximate = 4
	}
}
