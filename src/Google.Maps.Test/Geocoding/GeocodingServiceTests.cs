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

using System.Linq;
using NUnit.Framework;
using Google.Maps.Geocoding;
using System;

namespace Google.Maps.Test.Integrations
{
	[TestFixture]
	class GeocodingServiceTests
	{

		private static double GetTolerance(double expected, int decimalPrecision)
		{
			int magnitude = 1 +(expected==0.0 ? -1 : Convert.ToInt32(Math.Floor(Math.Log10(expected))));
			int precision = 15 - magnitude;

			double tolerance = 1.0 / Math.Pow(10,precision);

			return tolerance;
		}

		private static AddressComponent MakeAddressComponent(string shortName, string longName, params AddressType[] types)
		{
			return new AddressComponent()
			{
				ShortName = shortName,
				LongName = longName,
				Types = types
			};
		}
		private static Geometry MakeGeometry(LocationType locationType, double locationLat, double locationLong, double swLat, double swLong, double neLat, double neLong)
		{
			return new Geometry()
			{
				LocationType = locationType
				,
				Location = new LatLng(locationLat, locationLong)
				,
				Viewport = new Viewport(
				  southWest: new LatLng(swLat, swLong)
				  , northEast: new LatLng(neLat, neLong)
					)
			};
		}

		#region TestFixtureSetup/TearDown
		[TestFixtureSetUp]
		public void FixtureSetup()
		{
			Google.Maps.Internal.Http.Factory = new Google.Maps.Test.Integrations.HttpGetResponseFromResourceFactory("Google.Maps.Test.Geocoding");
		}
		[TestFixtureTearDown]
		public void FixtureTearDown()
		{
			Google.Maps.Internal.Http.Factory = new Internal.Http.HttpGetResponseFactory();
		}
		#endregion

		[Test]
		public void Empty_address()
		{
			// expectations
			var expectedStatus = ServiceResponseStatus.ZeroResults;
			var expectedResultCount = 0;

			// test
			var request = new GeocodingRequest();
			request.Sensor = false;
			request.Address = "";
			var response = new GeocodingService().GetResponse(request);

			// asserts
			Assert.AreEqual(expectedStatus, response.Status);
			Assert.AreEqual(expectedResultCount, response.Results.Count());
		}

		[Test]
		public void GetGeocodingForAddress1()
		{
			// expectations
			var expectedStatus = ServiceResponseStatus.Ok;
			var expectedResultCount = 1;
			var expectedType = AddressType.StreetAddress;
			var expectedFormattedAddress = "1600 Amphitheatre Parkway, Mountain View, CA 94043, USA";
			var expectedComponentTypes = new AddressType[] { 
				AddressType.StreetNumber, 
				AddressType.Route,
				AddressType.Locality,
				AddressType.AdministrativeAreaLevel1,
				AddressType.AdministrativeAreaLevel2,
				AddressType.AdministrativeAreaLevel3,
				AddressType.Country,
				AddressType.PostalCode,
				AddressType.Political
			};
			var expectedLocation = new LatLng(37.42219410, -122.08459320);
			var expectedLocationType = LocationType.Rooftop;
			Viewport expectedViewport = new Viewport(
				southWest: new LatLng(37.42084511970850, -122.0859421802915),
				northEast: new LatLng(37.42354308029149, -122.0832442197085)
			);

			// test
			var request = new GeocodingRequest();
			request.Address = "1600 Amphitheatre Parkway Mountain View CA";
			request.Sensor = false;
			var response = new GeocodingService().GetResponse(request);

			// asserts
			Assert.AreEqual(expectedStatus, response.Status, "Status");
			Assert.AreEqual(expectedResultCount, response.Results.Length, "ResultCount");
			Assert.AreEqual(expectedType, response.Results.Single().Types.First(), "Type");
			Assert.AreEqual(expectedFormattedAddress, response.Results.Single().FormattedAddress, "FormattedAddress");
			//Assert.IsTrue(
			//    expectedComponentTypes.OrderBy(x => x).SequenceEqual(
			//        response.Results.Single().AddressComponents.SelectMany(y => y.Types).Distinct().OrderBy(z => z)), "Types");
			//Assert.AreEqual(expectedLatitude, response.Results.Single().Geometry.Location.Latitude, "Latitude");
			Assert.That(expectedLocation, Is.EqualTo(response.Results[0].Geometry.Location).Using(LatLngComparer.Within(0.000001f)), "Longitude");
			Assert.AreEqual(expectedLocationType, response.Results.Single().Geometry.LocationType, "LocationType");
			//Assert.AreEqual(expectedSouthwestLatitude, response.Results.Single().Geometry.Viewport.Southwest.Latitude, "Southwest.Latitude");
			//Assert.AreEqual(expectedSouthwestLongitude, response.Results.Single().Geometry.Viewport.Southwest.Longitude, "Southwest.Longitude");
			//Assert.AreEqual(expectedNortheastLatitude, response.Results.Single().Geometry.Viewport.Northeast.Latitude, "Northeast.Latitude");
			//Assert.AreEqual(expectedNortheastLongitude, response.Results.Single().Geometry.Viewport.Northeast.Longitude, "Northeast.Longitude");
		}


		[Test]
		public void GetGeocodingForAddress2()
		{
			// expectations
			GeocodeResponse expected = new GeocodeResponse()
			{
				Status = ServiceResponseStatus.Ok,
				Results = new Result[] { 
					new Result() {
						
						AddressComponents = new AddressComponent[] {
							MakeAddressComponent("11","11",	AddressType.StreetNumber)
							, MakeAddressComponent("Wall St","Wall Street", AddressType.Route)
							, MakeAddressComponent("Lower Manhattan", "Lower Manhattan", AddressType.Neighborhood, AddressType.Political)
							, MakeAddressComponent("Manhattan", "Manhattan", AddressType.Sublocality, AddressType.Political)
							, MakeAddressComponent("New York", "New York", AddressType.Locality, AddressType.Political)
							, MakeAddressComponent("New York", "New York", AddressType.AdministrativeAreaLevel2, AddressType.Political)
							, MakeAddressComponent("NY", "New York", AddressType.AdministrativeAreaLevel1, AddressType.Political)
							, MakeAddressComponent("US", "United States", AddressType.Country, AddressType.Political)
						}
						, FormattedAddress = "11 Wall Street, New York, NY 10005, USA"
						, Geometry = MakeGeometry(LocationType.Rooftop, 
								40.7068599,-74.0111281 //location
								, 40.7055109,-74.0124771 //swBound
								, 40.7082089,-74.0097791) //neBound
						, Types = new AddressType[] { AddressType.StreetAddress }
					}
				}
			};


			// test
			var request = new GeocodingRequest();
			request.Address = "11 Wall Street New York NY 10005";
			request.Sensor = false;
			var actual = new GeocodingService().GetResponse(request);

			// asserts
			Assert.AreEqual(expected.Status, actual.Status, "Status");
			Assert.AreEqual(expected.Results.Length, actual.Results.Length, "ResultCount");
			
			var expectedResult = expected.Results.First(); var actualResult = actual.Results.First();
			Assert.AreEqual(expectedResult.Types, actualResult.Types, "Result.First().Types");
			Assert.AreEqual(expectedResult.FormattedAddress, actualResult.FormattedAddress, "Resut.First().FormattedAddress");

			//Assert.That(expectedResult.AddressComponents, Is.EquivalentTo(actualResult.AddressComponents));
			
			//Assert.IsTrue(
			//    expectedComponentTypes.OrderBy(x => x).SequenceEqual(
			//        response.Results.Single().AddressComponents.SelectMany(y => y.Types).Distinct().OrderBy(z => z)), "Types");

			//tolerance needed when testing doubles
			//http://stackoverflow.com/questions/4787125/evaluate-if-two-doubles-are-equal-based-on-a-given-precision-not-within-a-certa
			//double tolerance = GetTolerance(expectedResult.Geometry.Viewport.Southwest.Latitude, 7);
			//Assert.That(expectedResult.Geometry.Viewport.Southwest, Is.EqualTo(actualResult.Geometry.Viewport.Southwest).Within(latlngTolerance));
			//Assert.That(expectedResult.Geometry.Viewport.Southwest, Is.EqualTo(actualResult.Geometry.Viewport.Southwest).Within(0.0000001d));
			
			//Assert.AreEqual(expectedLatitude, response.Results.Single().Geometry.Location.Latitude, "Latitude");
			//Assert.AreEqual(expectedLongitude, response.Results.Single().Geometry.Location.Longitude, "Longitude");
			//Assert.AreEqual(expectedLocationType, response.Results.Single().Geometry.LocationType, "LocationType");
			//Assert.AreEqual(expectedSouthwestLatitude, response.Results.Single().Geometry.Viewport.Southwest.Latitude, "Southwest.Latitude");
			//Assert.AreEqual(expectedSouthwestLongitude, response.Results.Single().Geometry.Viewport.Southwest.Longitude, "Southwest.Longitude");
			//Assert.AreEqual(expectedNortheastLatitude, response.Results.Single().Geometry.Viewport.Northeast.Latitude, "Northeast.Latitude");
			//Assert.AreEqual(expectedNortheastLongitude, response.Results.Single().Geometry.Viewport.Northeast.Longitude, "Northeast.Longitude");
		}


		//[Test]
		//public void GetGeocodingForCoordinates()
		//{
		//    // expectations
		//    var expectedStatus = ServiceResponseStatus.Ok;
		//    var expectedResultCount = 9;
		//    var expectedTypes = new AddressType[] {
		//        AddressType.StreetAddress,
		//        AddressType.Locality,
		//        AddressType.PostalCode,
		//        AddressType.Sublocality,
		//        AddressType.AdministrativeAreaLevel2,
		//        AddressType.AdministrativeAreaLevel1,
		//        AddressType.Country,
		//        AddressType.Political
		//    };
		//    var expectedFormattedAddress = "277 Bedford Ave, Brooklyn, NY 11211, USA";
		//    var expectedComponentTypes = new AddressType[] { 
		//        AddressType.StreetNumber, 
		//        AddressType.Route,
		//        AddressType.Locality,
		//        AddressType.AdministrativeAreaLevel1,
		//        AddressType.AdministrativeAreaLevel2,
		//        AddressType.Sublocality,
		//        AddressType.Country,
		//        AddressType.PostalCode,
		//        AddressType.Political
		//    };
		//    double expectedLatitude = 40.7142330;
		//    double expectedLongitude = -73.9612910;
		//    LocationType expectedLocationType = LocationType.Rooftop;
		//    double expectedSouthwestLatitude = 40.7110854;
		//    double expectedSouthwestLongitude = -73.9644386;
		//    double expectedNortheastLatitude = 40.7173806;
		//    double expectedNortheastLongitude = -73.9581434;

		//    // test
		//    var request = new GeocodingRequest();
		//    request.Address = new LatLng(expectedLatitude, expectedLongitude);
		//    request.Sensor = false;
		//    var response = GeocodingService.GetResponse(request);

		//    // asserts
		//    Assert.AreEqual(expectedStatus, response.Status, "Status");
		//    Assert.AreEqual(expectedResultCount, response.Results.Length, "ResultCount");
		//    Assert.IsTrue(
		//        expectedTypes.OrderBy(x => x).SequenceEqual(
		//            response.Results.SelectMany(y => y.Types).Distinct().OrderBy(z => z)));
		//    Assert.AreEqual(expectedFormattedAddress, response.Results.First().FormattedAddress, "FormattedAddress");
		//    //Assert.IsTrue(
		//    //    expectedComponentTypes.OrderBy(x => x).SequenceEqual(
		//    //        response.Results.First().AddressComponents.SelectMany(y => y.Types).Distinct().OrderBy(z => z)), "Types");
		//    Assert.AreEqual(expectedLatitude, response.Results.First().Geometry.Location.Latitude, "Latitude");
		//    Assert.AreEqual(expectedLongitude, response.Results.First().Geometry.Location.Longitude, "Longitude");
		//    Assert.AreEqual(expectedLocationType, response.Results.First().Geometry.LocationType, "LocationType");
		//    Assert.AreEqual(expectedSouthwestLatitude, response.Results.First().Geometry.Viewport.Southwest.Latitude, "Southwest.Latitude");
		//    Assert.AreEqual(expectedSouthwestLongitude, response.Results.First().Geometry.Viewport.Southwest.Longitude, "Southwest.Longitude");
		//    Assert.AreEqual(expectedNortheastLatitude, response.Results.First().Geometry.Viewport.Northeast.Latitude, "Northeast.Latitude");
		//    Assert.AreEqual(expectedNortheastLongitude, response.Results.First().Geometry.Viewport.Northeast.Longitude, "Northeast.Longitude");
		//}
	}
}
