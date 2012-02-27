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
using Google.Maps.Geocoding;
using Newtonsoft.Json;

namespace Google.Maps
{

	public class JsonEnumTypeConverter : JsonConverter
	{
		public static ServiceResponseStatus AsResponseStatus(string s)
		{
			var result = ServiceResponseStatus.Unknown;

			switch (s)
			{
				case "OK":
					result = ServiceResponseStatus.Ok;
					break;
				case "ZERO_RESULTS":
					result = ServiceResponseStatus.ZeroResults;
					break;
				case "OVER_QUERY_LIMIT":
					result = ServiceResponseStatus.OverQueryLimit;
					break;
				case "REQUEST_DENIED":
					result = ServiceResponseStatus.RequestDenied;
					break;
				case "INVALID_REQUEST":
					result = ServiceResponseStatus.InvalidRequest;
					break;
			}

			return result;
		}

		public static AddressType AsAddressType(string s)
		{
			var result = AddressType.Unknown;

			switch (s)
			{
				case "street_address":
					result = AddressType.StreetAddress;
					break;
				case "route":
					result = AddressType.Route;
					break;
				case "intersection":
					result = AddressType.Intersection;
					break;
				case "political":
					result = AddressType.Political;
					break;
				case "country":
					result = AddressType.Country;
					break;
				case "administrative_area_level_1":
					result = AddressType.AdministrativeAreaLevel1;
					break;
				case "administrative_area_level_2":
					result = AddressType.AdministrativeAreaLevel2;
					break;
				case "administrative_area_level_3":
					result = AddressType.AdministrativeAreaLevel3;
					break;
				case "colloquial_area":
					result = AddressType.ColloquialArea;
					break;
				case "locality":
					result = AddressType.Locality;
					break;
				case "sublocality":
					result = AddressType.Sublocality;
					break;
				case "neighborhood":
					result = AddressType.Neighborhood;
					break;
				case "premise":
					result = AddressType.Premise;
					break;
				case "subpremise":
					result = AddressType.Subpremise;
					break;
				case "postal_code":
					result = AddressType.PostalCode;
					break;
				case "natural_feature":
					result = AddressType.NaturalFeature;
					break;
				case "airport":
					result = AddressType.Airport;
					break;
				case "park":
					result = AddressType.Park;
					break;
				case "point_of_interest":
					result = AddressType.PointOfInterest;
					break;
				case "post_box":
					result = AddressType.PostBox;
					break;
				case "street_number":
					result = AddressType.StreetNumber;
					break;
				case "floor":
					result = AddressType.Floor;
					break;
				case "room":
					result = AddressType.Room;
					break;
			}

			return result;
		}

		public static LocationType AsLocationType(string s)
		{
			var result = LocationType.Unknown;

			switch (s)
			{
				case "ROOFTOP":
					result = LocationType.Rooftop;
					break;
				case "RANGE_INTERPOLATED":
					result = LocationType.RangeInterpolated;
					break;
				case "GEOMETRIC_CENTER":
					result = LocationType.GeometricCenter;
					break;
				case "APPROXIMATE":
					result = LocationType.Approximate;
					break;
			}

			return result;
		}
	
		public override bool CanConvert(Type objectType)
		{
			return
				objectType == typeof(ServiceResponseStatus)
				|| objectType == typeof(AddressType)
				|| objectType == typeof(LocationType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
		{
			object result = null;

			if(objectType == typeof(ServiceResponseStatus))
				result = AsResponseStatus(reader.Value.ToString());

			if (objectType == typeof(AddressType))
				result = AsAddressType(reader.Value.ToString());

			if (objectType == typeof(LocationType))
				result = AsLocationType(reader.Value.ToString());

			return result;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new System.NotImplementedException();
		}
	}
}
