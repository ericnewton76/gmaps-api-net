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

namespace Google.Maps.Geocoding
{
	public enum AddressType
	{
		Unknown,

		/// <summary>
		/// Indicates a precise street address.
		/// </summary>
		StreetAddress,

		/// <summary>
		/// Indicates a named route (such as "US 101").
		/// </summary>
		Route,

		/// <summary>
		/// Indicates a major intersection, usually of two major roads.
		/// </summary>
		Intersection,

		/// <summary>
		/// Indicates a political entity. Usually, this type indicates a polygon of
		/// some civil administration.
		/// </summary>
		Political,

		/// <summary>
		/// Indicates the national political entity, and is typically the highest
		/// order type returned by the Geocoder.
		/// </summary>
		Country,

		/// <summary>
		/// Indicates a first-order civil entity below the country level. Within the
		/// United States, these administrative levels are states. Not all nations
		/// exhibit these administrative levels.
		/// </summary>
		AdministrativeAreaLevel1,

		/// <summary>
		/// Indicates a second-order civil entity below the country level. Within the
		/// United States, these administrative levels are counties. Not all nations
		/// exhibit these administrative levels.
		/// </summary>
		AdministrativeAreaLevel2,

		/// <summary>
		/// Indicates a third-order civil entity below the country level. This type
		/// indicates a minor civil division. Not all nations exhibit these
		/// administrative levels.
		/// </summary>
		AdministrativeAreaLevel3,

		/// <summary>
		/// Indicates a commonly-used alternative name for the entity.
		/// </summary>
		ColloquialArea,

		/// <summary>
		/// Indicates an incorporated city or town political entity.
		/// </summary>
		Locality,

		/// <summary>
		/// Indicates an first-order civil entity below a locality.
		/// </summary>
		Sublocality,

		/// <summary>
		/// Indicates a named neighborhood.
		/// </summary>
		Neighborhood,

		/// <summary>
		/// Indicates a named location, usually a building or collection of
		/// buildings with a common name.
		/// </summary>
		Premise,

		/// <summary>
		/// Indicates a first-order entity below a named location, usually a
		/// singular building within a collection of buildings with a common
		/// name.
		/// </summary>
		Subpremise,

		/// <summary>
		/// Indicates a postal code as used to address postal mail within the
		/// country.
		/// </summary>
		PostalCode,

		/// <summary>
		/// Indicates a prominent natural feature.
		/// </summary>
		NaturalFeature,

		/// <summary>
		/// Indicates an airport.
		/// </summary>
		Airport,

		/// <summary>
		/// Indicates a named park.
		/// </summary>
		Park,

		/// <summary>
		/// Indicates a named point of interest. Typically, these "POI"s are
		/// prominent local entities that don't easily fit in another category
		/// such as "Empire State Building" or "Statue of Liberty."
		/// </summary>
		PointOfInterest,

		/// <summary>
		/// Indicates a specific postal box.
		/// </summary>
		PostBox,

		/// <summary>
		/// Indicates the precise street number.
		/// </summary>
		StreetNumber,

		/// <summary>
		/// Indicates the floor of a building address.
		/// </summary>
		Floor,

		/// <summary>
		/// Indicates the room of a building address.
		/// </summary>
		Room
	}
}
