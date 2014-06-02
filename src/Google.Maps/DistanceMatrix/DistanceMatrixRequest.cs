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
using Google.Maps;
using System.Text;

namespace Google.Maps.DistanceMatrix
{
	/// <summary>
	/// Provides a request for the Google Distance Matrix web service.
	/// </summary>
    public class DistanceMatrixRequest : ApiRequest
	{
		/// <summary>
		/// (optional) Specifies what mode of transport to use when calculating directions.
		/// </summary>
		public TravelMode Mode { get; set; }

		/// <summary>
		/// (optional) Directions may be calculated that adhere to certain restrictions.
		/// </summary>
		public Avoid Avoid { get; set; }

		/// <summary>
		///  (optional) Specifies the unit system to use when expressing distance as text.
		///   <see cref="http://code.google.com/intl/it-IT/apis/maps/documentation/distancematrix/#unit_systems"/>
		/// </summary>
		public Units Units { get; set; }

		/// <summary>
		/// (optional) The language in which to return results.
		/// <see cref="http://code.google.com/apis/maps/faq.html#languagesupport" />
		/// </summary>
		public string Language { get; set; }

		/// <summary>
		///  List of origin waypoints
		/// </summary>
		private SortedList<int, Waypoint> waypointsOrigin;

		/// <summary>
		/// List of destination waypoints
		/// </summary>
		private SortedList<int, Waypoint> waypointsDestination;

		/// <summary>
		/// Accessor method
		/// </summary>
		public SortedList<int, Waypoint> WaypointsOrigin
		{
			get
			{
				if (waypointsOrigin == null)
				{
					waypointsOrigin = new SortedList<int, Waypoint>();
				}
				return waypointsOrigin;
			}
			set
			{
				waypointsOrigin = value;
			}
		}//end method

		/// <summary>
		/// Accessor method
		/// </summary>
		public SortedList<int, Waypoint> WaypointsDestination
		{
			get
			{
				if (waypointsDestination == null)
				{
					waypointsDestination = new SortedList<int, Waypoint>();
				}
				return waypointsDestination;
			}
			set
			{
				waypointsDestination = value;
			}
		}//end method

		/// <summary>
		/// 
		/// </summary>
		/// <param name="destination"></param>
		public void AddOrigin(Waypoint destination)
		{
			WaypointsOrigin.Add(WaypointsOrigin.Count, destination);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="destination"></param>
		public void AddDestination(Waypoint destination)
		{
			WaypointsDestination.Add(WaypointsDestination.Count, destination);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		internal string WaypointsToUri(SortedList<int, Waypoint> Waypoints)
		{
			if (Waypoints.Count == 0) return string.Empty;

			StringBuilder sb = new StringBuilder();

			foreach (Waypoint waypoint in Waypoints.Values)
			{
				sb.AppendFormat("{0}|", waypoint.ToString());
			}
			sb = sb.Remove(sb.Length - 1, 1);
			return sb.ToString();
		}//end method

		/// <summary>
		/// Create URI for quering
		/// </summary>
		/// <returns></returns>
        public override Uri ToUri()
		{
			this.EnsureSensor();

			var qsb = new Internal.QueryStringBuilder()
				.Append("origins", WaypointsToUri(waypointsOrigin))
				.Append("destinations", WaypointsToUri(WaypointsDestination))
				.Append("mode", Mode.ToString())
				.Append("language", Language)
				.Append("units", Units.ToString())
				.Append("sensor", (Sensor.Value ? "true" : "false"))
				.Append("avoid", Avoid.ToString());

			var url = "json?" + qsb.ToString();

			return new Uri(url, UriKind.Relative);
		}
	}

}
