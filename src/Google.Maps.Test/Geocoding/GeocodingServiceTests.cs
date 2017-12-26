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
using System.Linq;
using System.Net.Http;

using NUnit.Framework;

using Google.Maps.Shared;

namespace Google.Maps.Geocoding
{
	[TestFixture]
	class GeocodingServiceTests
	{
		GoogleSigned TestingApiKey;

		GeocodingService CreateService()
		{
			var svc = new GeocodingService(TestingApiKey);
			return svc;
		}

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			TestingApiKey = SigningHelper.GetApiKey();
		}

		[Test]
		public void Empty_address()
		{
			Assert.Throws<HttpRequestException>(() =>
			{
				var request = new GeocodingRequest { Address = "" };
				var response = CreateService().GetResponse(request);
			});
		}

		[Test]
		[Category("ValueTesting")]
		public void GetGeocodingForAddress1()
		{
			// Arrange
			var request = new GeocodingRequest { Address = "1600 Amphitheatre Parkway Mountain View CA" };

			// Act
			var response = CreateService().GetResponse(request);

			// Assert
			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
			Assert.AreEqual(1, response.Results.Length);

			var result = response.Results.Single();
			Assert.AreEqual("Google Bldg 42, 1600 Amphitheatre Pkwy, Mountain View, CA 94043, USA", result.FormattedAddress);
			Assert.AreEqual(LocationType.Rooftop, result.Geometry.LocationType);

			var expectedLocation = new LatLng(37.42219410, -122.08459320);
			Assert.That(expectedLocation, Is.EqualTo(result.Geometry.Location).Using(LatLngComparer.Within(0.00001f)));

			Viewport expectedViewport = new Viewport(
				southWest: new LatLng(37.42084511970850, -122.0859421802915),
				northEast: new LatLng(37.42354308029149, -122.0832442197085)
			);
			Assert.That(expectedViewport.Southwest, Is.EqualTo(result.Geometry.Viewport.Southwest).Using(LatLngComparer.Within(0.00001f)));
			Assert.That(expectedViewport.Northeast, Is.EqualTo(result.Geometry.Viewport.Northeast).Using(LatLngComparer.Within(0.00001f)));
		}

		[Test]
		[Category("ValueTesting")]
		public void GetGeocodingForAddress2()
		{
			// test
			var request = new GeocodingRequest();
			request.Address = "11 Wall Street New York NY 10005";
			var actual = CreateService().GetResponse(request);

			// asserts
			Assert.AreEqual(ServiceResponseStatus.Ok, actual.Status);
			Assert.AreEqual(1, actual.Results.Length);

			var actualResult = actual.Results.Single();
			Assert.AreEqual(new AddressType[] { AddressType.StreetAddress }, actualResult.Types);
			Assert.AreEqual("11 Wall St, New York, NY 10005, USA", actualResult.FormattedAddress);
		}

		[Test]
		[Category("ValueTesting")]
		public void Geocode_With_AddressComponent_Locking()
		{
			var requestGB = new GeocodingRequest
			{
				Address = "Boston",
				Components = "country:GB"
			};

			var requestUS = new GeocodingRequest
			{
				Address = "Boston",
				Components = "country:US"
			};

			var responseGB = CreateService().GetResponse(requestGB);
			var responseUS = CreateService().GetResponse(requestUS);

			Assert.AreEqual(ServiceResponseStatus.Ok, responseGB.Status);
			Assert.AreEqual(ServiceResponseStatus.Ok, responseUS.Status);

			foreach (var r in responseGB.Results)
			{
				Assert.IsTrue(r.FormattedAddress.EndsWith("UK"), r.FormattedAddress + " <- Should be in UK");
			}

			foreach (var r in responseUS.Results)
			{
				Assert.IsTrue(r.FormattedAddress.EndsWith("USA"), r.FormattedAddress + " <- Should be in USA");
			}
		}

		[Test]
		[Category("ValueTesting")]
		public void Geocode_Without_AddressComponent_Locking()
		{
			var request = new GeocodingRequest
			{
				Address = "Boston"
			};

			var response = CreateService().GetResponse(request);

			foreach (var r in response.Results)
			{
				Assert.IsTrue(r.FormattedAddress.EndsWith("USA"));
			}
		}

		[Test]
		[Category("ValueTesting")]
		public void GeocodeResult_Has_BoundsProperty()
		{
			var request = new GeocodingRequest
			{
				Address = "Boston"
			};

			var response = CreateService().GetResponse(request);

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
			Assert.IsNotNull(response.Results[0].Geometry.Bounds);
			Assert.IsNotNull(response.Results[0].Geometry.Bounds.Southwest);
			Assert.IsNotNull(response.Results[0].Geometry.Bounds.Northeast);
		}

		[Test]
		[Category("ValueTesting")]
		public void GeocodeResult_Supports_PostalTownAndPostalCodePrefix()
		{
			var request = new GeocodingRequest
			{
				Address = "Stathern, UK"
			};

			var response = CreateService().GetResponse(request);

			var postalTown = response.Results[0].AddressComponents.First(x => x.ShortName == "Melton Mowbray");
			Assert.IsFalse(postalTown.Types.Contains(AddressType.Unknown), postalTown.ShortName + " should be AddressType PostalTown");

			var postalCodePrefix = response.Results[0].AddressComponents.First(x => x.ShortName == "LE14");
			Assert.IsFalse(postalCodePrefix.Types.Contains(AddressType.Unknown), postalCodePrefix.ShortName + " should be AddressType PostalCodePrefix");
		}

		[Test]
		[Category("ValueTesting")]
		public void Utf8_Request_And_Response()
		{
			var request = new GeocodingRequest
			{
				Address = "AL. GRUNWALDZKA 141, Gdańsk, 80 - 264, POLAND"
			};

			var response = new GeocodingService().GetResponse(request);

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
			Assert.AreEqual(LocationType.Rooftop, response.Results[0].Geometry.LocationType);
			Assert.AreEqual("Gdańsk", response.Results[0].AddressComponents[3].LongName);
		}
	}
}
