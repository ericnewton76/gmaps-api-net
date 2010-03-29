/*
 * 
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 * 
 */
namespace Google.Api.Maps.Core.StaticMaps
{
	public enum MapType
	{
		Default,

		/// <summary>
		/// Specifies a standard roadmap image, as is normally shown on the
		/// Google Maps website.
		/// </summary>
		Roadmap,

		/// <summary>
		/// Specifies a satellite image.
		/// </summary>
		Satellite,

		/// <summary>
		/// Specifies a physical relief map image, showing terrain and vegetation.
		/// </summary>
		Terrain,

		/// <summary>
		/// Specifies a hybrid of the satellite and roadmap image, showing a
		/// transparent layer of major streets and place names on the satellite
		/// image.
		/// </summary>
		Hybrid
	}
}
