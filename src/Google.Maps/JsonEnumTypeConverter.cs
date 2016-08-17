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
using Google.Maps.Shared;
using Newtonsoft.Json;

namespace Google.Maps
{

	public class JsonEnumTypeConverter : JsonConverter
	{
		public static ServiceResponseStatus AsResponseStatus(string s)
		{
			var result = ServiceResponseStatus.Unknown;

			switch(s)
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

			switch(s)
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
				case "postal_town":
					result = AddressType.PostalTown;
					break;
				case "postal_code_prefix":
					result = AddressType.PostalCodePrefix;
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

		private static Places.PlaceType AsPlaceType(string s)
		{
			var result = Places.PlaceType.Unknown;
			switch(s)
			{
				case "accounting":
					result = Places.PlaceType.Accounting;
					break;
				case "airport":
					result = Places.PlaceType.Airport;
					break;
				case "amusement_park":
					result = Places.PlaceType.AmusementPark;
					break;
				case "aquarium":
					result = Places.PlaceType.Aquarium;
					break;
				case "art_gallery":
					result = Places.PlaceType.ArtGallery;
					break;
				case "atm":
					result = Places.PlaceType.ATM;
					break;
				case "bakery":
					result = Places.PlaceType.Bakery;
					break;
				case "bank":
					result = Places.PlaceType.Bank;
					break;
				case "bar":
					result = Places.PlaceType.Bar;
					break;
				case "beauty_salon":
					result = Places.PlaceType.BeautySalon;
					break;
				case "bicycle_store":
					result = Places.PlaceType.BicycleStore;
					break;
				case "book_store":
					result = Places.PlaceType.BookStore;
					break;
				case "bowling_alley":
					result = Places.PlaceType.BowlingAlley;
					break;
				case "bus_station":
					result = Places.PlaceType.BusStation;
					break;
				case "cafe":
					result = Places.PlaceType.Cafe;
					break;
				case "campground":
					result = Places.PlaceType.Campground;
					break;
				case "car_dealer":
					result = Places.PlaceType.CarDealer;
					break;
				case "car_rental":
					result = Places.PlaceType.CarRental;
					break;
				case "car_repair":
					result = Places.PlaceType.CarRepair;
					break;
				case "car_wash":
					result = Places.PlaceType.CarRepair;
					break;
				case "casino":
					result = Places.PlaceType.Casino;
					break;
				case "cemetery":
					result = Places.PlaceType.Cemetery;
					break;
				case "church":
					result = Places.PlaceType.Church;
					break;
				case "city_hall":
					result = Places.PlaceType.CityHall;
					break;
				case "clothing_store":
					result = Places.PlaceType.ClotingStore;
					break;
				case "convenience_store":
					result = Places.PlaceType.ConvenienceStore;
					break;
				case "courthouse":
					result = Places.PlaceType.CourtHouse;
					break;
				case "dentist":
					result = Places.PlaceType.Dentist;
					break;
				case "department_store":
					result = Places.PlaceType.DepartmentStore;
					break;
				case "doctor":
					result = Places.PlaceType.Doctor;
					break;
				case "electrician":
					result = Places.PlaceType.Electrician;
					break;
				case "electronics_store":
					result = Places.PlaceType.ElectronicsStore;
					break;
				case "embassy":
					result = Places.PlaceType.Embassy;
					break;
				case "establishment":
					result = Places.PlaceType.Establishment;
					break;
				case "finance":
					result = Places.PlaceType.Finance;
					break;
				case "fire_station":
					result = Places.PlaceType.FireStation;
					break;
				case "florist":
					result = Places.PlaceType.Florist;
					break;
				case "food":
					result = Places.PlaceType.Food;
					break;
				case "funeral_home":
					result = Places.PlaceType.FuneralHome;
					break;
				case "furniture_store":
					result = Places.PlaceType.FurnitureStore;
					break;
				case "gas_station":
					result = Places.PlaceType.GasStation;
					break;
				case "general_contractor":
					result = Places.PlaceType.GeneralContractor;
					break;
				case "grocery_or_supermarket":
					result = Places.PlaceType.GroceryOrSupermarket;
					break;
				case "gym":
					result = Places.PlaceType.Gym;
					break;
				case "hair_care":
					result = Places.PlaceType.HairCare;
					break;
				case "hardware_store":
					result = Places.PlaceType.HardwareStore;
					break;
				case "health":
					result = Places.PlaceType.Health;
					break;
				case "hindu_temple":
					result = Places.PlaceType.HinduTemple;
					break;
				case "home_goods_store":
					result = Places.PlaceType.HomeGoodsStore;
					break;
				case "hospital":
					result = Places.PlaceType.Hospital;
					break;
				case "insurance_agency":
					result = Places.PlaceType.InsuranceAgency;
					break;
				case "jewelry_store":
					result = Places.PlaceType.JewelryStore;
					break;
				case "laundry":
					result = Places.PlaceType.Laundry;
					break;
				case "lawyer":
					result = Places.PlaceType.Lawyer;
					break;
				case "library":
					result = Places.PlaceType.Library;
					break;
				case "liquor_store":
					result = Places.PlaceType.LiquorStore;
					break;
				case "local_government_office":
					result = Places.PlaceType.LocalGovermentOffice;
					break;
				case "locksmith":
					result = Places.PlaceType.Locksmith;
					break;
				case "lodging":
					result = Places.PlaceType.Lodging;
					break;
				case "meal_delivery":
					result = Places.PlaceType.MealDelivery;
					break;
				case "meal_takeaway":
					result = Places.PlaceType.MealTakeaway;
					break;
				case "mosque":
					result = Places.PlaceType.Mosque;
					break;
				case "movie_rental":
					result = Places.PlaceType.MovieRental;
					break;
				case "movie_theater":
					result = Places.PlaceType.MovieTheater;
					break;
				case "moving_company":
					result = Places.PlaceType.MovingCompany;
					break;
				case "museum":
					result = Places.PlaceType.Museum;
					break;
				case "night_club":
					result = Places.PlaceType.NightClub;
					break;
				case "painter":
					result = Places.PlaceType.Painter;
					break;
				case "park":
					result = Places.PlaceType.Park;
					break;
				case "parking":
					result = Places.PlaceType.Parking;
					break;
				case "pet_store":
					result = Places.PlaceType.PetStore;
					break;
				case "pharmacy":
					result = Places.PlaceType.Pharmacy;
					break;
				case "physiotherapist":
					result = Places.PlaceType.Physiotherapist;
					break;
				case "place_of_worship":
					result = Places.PlaceType.PlaceOfWorkship;
					break;
				case "plumber":
					result = Places.PlaceType.Plumber;
					break;
				case "police":
					result = Places.PlaceType.Police;
					break;
				case "post_office":
					result = Places.PlaceType.PostOffice;
					break;
				case "real_estate_agency":
					result = Places.PlaceType.RealEstateAgency;
					break;
				case "restaurant":
					result = Places.PlaceType.Restaurant;
					break;
				case "roofing_contractor":
					result = Places.PlaceType.RoofingContractor;
					break;
				case "rv_park":
					result = Places.PlaceType.RVPark;
					break;
				case "school":
					result = Places.PlaceType.School;
					break;
				case "shoe_store":
					result = Places.PlaceType.ShoeStore;
					break;
				case "shopping_mall":
					result = Places.PlaceType.ShoppingMall;
					break;
				case "spa":
					result = Places.PlaceType.Spa;
					break;
				case "stadium":
					result = Places.PlaceType.Stadium;
					break;
				case "storage":
					result = Places.PlaceType.Storage;
					break;
				case "store":
					result = Places.PlaceType.Store;
					break;
				case "subway_station":
					result = Places.PlaceType.SubwayStation;
					break;
				case "synagogue":
					result = Places.PlaceType.Synagogue;
					break;
				case "taxi_stand":
					result = Places.PlaceType.TaxiStation;
					break;
				case "train_station":
					result = Places.PlaceType.TrainStation;
					break;
				case "travel_agency":
					result = Places.PlaceType.TravelAgency;
					break;
				case "university":
					result = Places.PlaceType.University;
					break;
				case "veterinary_care":
					result = Places.PlaceType.VeterinaryCare;
					break;
				case "zoo":
					result = Places.PlaceType.Zoo;
					break;
				case "administrative_area_level_1":
					result = Places.PlaceType.AdministrativeAreaLevel1;
					break;
				case "administrative_area_level_2":
					result = Places.PlaceType.AdministrativeAreaLevel2;
					break;
				case "administrative_area_level_3":
					result = Places.PlaceType.AdministrativeAreaLevel3;
					break;
				case "colloquial_area":
					result = Places.PlaceType.ColloquialArea;
					break;
				case "country":
					result = Places.PlaceType.Country;
					break;
				case "floor":
					result = Places.PlaceType.Floor;
					break;
				case "geocode":
					result = Places.PlaceType.Geocode;
					break;
				case "intersection":
					result = Places.PlaceType.Intersection;
					break;
				case "locality":
					result = Places.PlaceType.Locality;
					break;
				case "natural_feature":
					result = Places.PlaceType.NaturalFeature;
					break;
				case "neighborhood":
					result = Places.PlaceType.Neighborhood;
					break;
				case "political":
					result = Places.PlaceType.Political;
					break;
				case "point_of_interest":
					result = Places.PlaceType.PointOfInterest;
					break;
				case "post_box":
					result = Places.PlaceType.PostBox;
					break;
				case "postal_code":
					result = Places.PlaceType.PostalCode;
					break;
				case "postal_code_prefix":
					result = Places.PlaceType.PostalCodePrefix;
					break;
				case "postal_town":
					result = Places.PlaceType.PostalTown;
					break;
				case "premise":
					result = Places.PlaceType.Premise;
					break;
				case "room":
					result = Places.PlaceType.Room;
					break;
				case "route":
					result = Places.PlaceType.Route;
					break;
				case "street_address":
					result = Places.PlaceType.StreetAddress;
					break;
				case "street_number":
					result = Places.PlaceType.StreetNumber;
					break;
				case "sublocality":
					result = Places.PlaceType.Sublocality;
					break;
				case "sublocality_level_4":
					result = Places.PlaceType.SublocalityLevel4;
					break;
				case "sublocality_level_5":
					result = Places.PlaceType.SublocalityLevel5;
					break;
				case "sublocality_level_3":
					result = Places.PlaceType.SublocalityLevel3;
					break;
				case "sublocality_level_2":
					result = Places.PlaceType.SublocalityLevel2;
					break;
				case "sublocality_level_1":
					result = Places.PlaceType.SublocalityLevel1;
					break;
				case "subpremise":
					result = Places.PlaceType.Subpremise;
					break;
				case "transit_station":
					result = Places.PlaceType.TransitStation;
					break;
			}
			return result;
		}

		public static LocationType AsLocationType(string s)
		{
			var result = LocationType.Unknown;

			switch(s)
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
				|| objectType == typeof(LocationType)
				|| objectType == typeof(Places.PlaceType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			object result = null;

			if(objectType == typeof(ServiceResponseStatus))
				result = AsResponseStatus(reader.Value.ToString());

			if(objectType == typeof(AddressType))
				result = AsAddressType(reader.Value.ToString());

			if(objectType == typeof(LocationType))
				result = AsLocationType(reader.Value.ToString());

			if(objectType == typeof(Places.PlaceType))
				result = AsPlaceType(reader.Value.ToString());

			return result;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new System.NotImplementedException();
		}
	}
}
