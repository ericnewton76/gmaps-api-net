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
	public enum AddressType
	{
		Unknown = 0,

		/// <summary>
		/// Indicates a precise street address.
		/// </summary>
		StreetAddress = 1,

		/// <summary>
		/// Indicates a named route (such as "US 101").
		/// </summary>
		Route = 2,

		/// <summary>
		/// Indicates a major intersection, usually of two major roads.
		/// </summary>
		Intersection = 3,

		/// <summary>
		/// Indicates a political entity. Usually, this type indicates a polygon of
		/// some civil administration.
		/// </summary>
		Political = 4,

		/// <summary>
		/// Indicates the national political entity, and is typically the highest
		/// order type returned by the Geocoder.
		/// </summary>
		Country = 5,

		/// <summary>
		/// Indicates a first-order civil entity below the country level. Within the
		/// United States, these administrative levels are states. Not all nations
		/// exhibit these administrative levels.
		/// </summary>
		AdministrativeAreaLevel1 = 6,

		/// <summary>
		/// Indicates a second-order civil entity below the country level. Within the
		/// United States, these administrative levels are counties. Not all nations
		/// exhibit these administrative levels.
		/// </summary>
		AdministrativeAreaLevel2 = 7,

		/// <summary>
		/// Indicates a third-order civil entity below the country level. This type
		/// indicates a minor civil division. Not all nations exhibit these
		/// administrative levels.
		/// </summary>
		AdministrativeAreaLevel3 = 8,

		/// <summary>
		/// Indicates a fourth-order civil entity below the country level. This type
		/// indicates a minor civil division. Not all nations exhibit these
		/// administrative levels.
		/// </summary>
		AdministrativeAreaLevel4 = 31,

		/// <summary>
		/// Indicates a fifth-order civil entity below the country level. This type
		/// indicates a minor civil division. Not all nations exhibit these
		/// administrative levels.
		/// </summary>
		AdministrativeAreaLevel5 = 32,

		/// <summary>
		/// Indicates a commonly-used alternative name for the entity.
		/// </summary>
		ColloquialArea = 9,

		/// <summary>
		/// Indicates an incorporated city or town political entity.
		/// </summary>
		Locality = 10,

		/// <summary>
		/// Indicates an first-order civil entity below a locality.
		/// </summary>
		Sublocality = 11,

		/// <summary>
		/// Indicates an first-order civil entity below a locality.
		/// </summary>
		SublocalityLevel1 = 26,

		/// <summary>
		/// Indicates an second-order civil entity below a locality.
		/// </summary>
		SublocalityLevel2 = 27,

		/// <summary>
		/// Indicates an third-order civil entity below a locality.
		/// </summary>
		SublocalityLevel3 = 28,

		/// <summary>
		/// Indicates an fourth-order civil entity below a locality.
		/// </summary>
		SublocalityLevel4 = 29,

		/// <summary>
		/// Indicates an fifth-order civil entity below a locality.
		/// </summary>
		SublocalityLevel5 = 30,

		/// <summary>
		/// Indicates a named neighborhood.
		/// </summary>
		Neighborhood = 12,

		/// <summary>
		/// Indicates a named location, usually a building or collection of
		/// buildings with a common name.
		/// </summary>
		Premise = 13,

		/// <summary>
		/// Indicates a first-order entity below a named location, usually a
		/// singular building within a collection of buildings with a common
		/// name.
		/// </summary>
		Subpremise = 14,

		/// <summary>
		/// Indicates a postal code as used to address postal mail within the
		/// country.
		/// </summary>
		PostalCode = 15,

		/// <summary>
		/// Indicates a prominent natural feature.
		/// </summary>
		NaturalFeature = 16,

		/// <summary>
		/// Indicates an airport.
		/// </summary>
		Airport = 17,

		/// <summary>
		/// Indicates a named park.
		/// </summary>
		Park = 18,

		/// <summary>
		/// Indicates a named point of interest. Typically, these "POI"s are
		/// prominent local entities that don't easily fit in another category
		/// such as "Empire State Building" or "Statue of Liberty."
		/// </summary>
		PointOfInterest = 19,

		/// <summary>
		/// Indicates a specific postal box.
		/// </summary>
		PostBox = 20,

		/// <summary>
		/// Indicates the precise street number.
		/// </summary>
		StreetNumber = 21,

		/// <summary>
		/// Indicates the floor of a building address.
		/// </summary>
		Floor = 22,

		/// <summary>
		/// Indicates the room of a building address.
		/// </summary>
		Room = 23,

		/// <summary>
		/// (Not documented) Indicates the Postal Town (nearest large town / city for UK addresses)
		/// </summary>
		PostalTown = 24,

		/// <summary>
		/// (Not documented) First half of postcode for the UK
		/// </summary>
		PostalCodePrefix = 25
	}
}