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
using Google.Maps.Direction;
using System;
using Google.Maps.Geocoding;

namespace Google.Maps.Test.Integrations
{
	[TestFixture]
	class DirectionServiceTests
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
			Google.Maps.Internal.Http.Factory = new Google.Maps.Test.Integrations.HttpGetResponseFromResourceFactory("Google.Maps.Test.Direction");
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

			// test
			var request = new DirectionRequest();
			request.Sensor = false;
			request.Origin = "";
			var response = new DirectionService().GetResponse(request);

			// asserts
			Assert.AreEqual(expectedStatus, response.Status);
		}

		[Test]
		public void GetResultForDirections_ex1()
		{
			// expectations
			var expectedStatus = ServiceResponseStatus.Ok;
			var expectedRoutesCount = 1;
			
			var expectedEndAddress = "Montreal, QC, Canada";
			var expectedEndLocation = new LatLng(45.508570, -73.553770);
			
			var expectedStartAddress = "Toronto, ON, Canada";
			var expectedStartLocation = new LatLng(43.653310, -79.382770);

			var expectedBounds = new Viewport(
				northEast: new LatLng(45.51048, -73.55332),
				southWest: new LatLng(43.65331, -79.38373)
			);

			var expectedDistance = new ValueText() { Text = "542 km", Value = "542382" };
			var expectedDuration = new ValueText() { Text = "5 hours 27 mins", Value = "19608" };

			var expectedSteps = 13;

			var expectedSummary = "ON-401 E";

			// test
			var request = new DirectionRequest();
			request.Origin = "Toronto";
			request.Destination = "Montreal";
			request.Sensor = false;
			
			var response = new DirectionService().GetResponse(request);

			// asserts
			Assert.AreEqual(expectedStatus, response.Status, "Status");
			Assert.AreEqual(expectedRoutesCount, response.Routes.Length, "ResultCount");

			var currentLeg = response.Routes[0].Legs[0];

			Assert.That(expectedStartAddress, Is.EqualTo(currentLeg.StartAddress), "Leg.StartAddress");
			Assert.That(expectedStartLocation, Is.EqualTo(currentLeg.StartLocation).Using(LatLngComparer.Within(0.000001f)), "Leg.StartLocation");
			
			Assert.That(expectedEndAddress, Is.EqualTo(currentLeg.EndAddress), "Leg.EndAddress");
			Assert.That(expectedEndLocation, Is.EqualTo(currentLeg.EndLocation).Using(LatLngComparer.Within(0.000001f)), "Leg.EndLocation");

			Assert.That(expectedDistance, Is.EqualTo(currentLeg.Distance).Using(new ValueTextComparer(StringComparer.InvariantCultureIgnoreCase)));
			Assert.That(expectedDuration, Is.EqualTo(currentLeg.Duration).Using(new ValueTextComparer(StringComparer.InvariantCultureIgnoreCase)));

			Assert.That(expectedSteps, Is.EqualTo(currentLeg.Steps.Count()), "Leg.Steps");

			Assert.That(expectedSummary, Is.EqualTo(response.Routes[0].Summary), "Route.Summary");
		}



	}
}
