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
using Google.Maps.Shared;

namespace Google.Maps.Test.Integrations
{
	[TestFixture]
	class DirectionServiceTests
	{

		private static double GetTolerance(double expected, int decimalPrecision)
		{
			int magnitude = 1 + (expected == 0.0 ? -1 : Convert.ToInt32(Math.Floor(Math.Log10(expected))));
			int precision = 15 - magnitude;

			double tolerance = 1.0 / Math.Pow(10, precision);

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
		[OneTimeSetUp]
		public void FixtureSetup()
		{
			Google.Maps.Internal.Http.Factory = new Google.Maps.Test.Integrations.HttpGetResponseFromResourceFactory("Google.Maps.Test.Direction");
		}

		[OneTimeTearDown]
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
			var expectedEndLocation = new LatLng(45.5017123, -73.5672184);

			var expectedStartAddress = "Toronto, ON, Canada";
			var expectedStartLocation = new LatLng(43.6533103, -79.3827675);

			var expectedBounds = new Viewport(
				northEast: new LatLng(45.51048, -73.55332),
				southWest: new LatLng(43.65331, -79.38373)
			);

			var expectedDistance = new ValueText() { Text = "541 km", Value = "540965" };
			var expectedDuration = new ValueText() { Text = "5 hours 17 mins", Value = "18996" };

			var expectedSteps = 16;

			var expectedSummary = "ON-401 E";

            var expectedWaypointStatus = ServiceResponseStatus.Ok;
            var expectedWaypointPartialMatch = true;
            var expectedWaypointAddressType1 = AddressType.Locality;
            var expectedWaypointAddressType2 = AddressType.Political;


			// test
			var request = new DirectionRequest();
			request.Origin = "Toront"; // Typo intended
			request.Destination = "Montreal";

			var response = new DirectionService().GetResponse(request);

			// asserts
			Assert.AreEqual(expectedStatus, response.Status, "Status");
			Assert.AreEqual(expectedRoutesCount, response.Routes.Length, "ResultCount");

			var currentLeg = response.Routes[0].Legs[0];

			Assert.That(currentLeg.StartAddress, Is.EqualTo(expectedStartAddress), "Leg.StartAddress");
			Assert.That(currentLeg.StartLocation, Is.EqualTo(expectedStartLocation).Using(LatLngComparer.Within(0.000001f)), "Leg.StartLocation");

			Assert.That(currentLeg.EndAddress, Is.EqualTo(expectedEndAddress), "Leg.EndAddress");
			Assert.That(currentLeg.EndLocation, Is.EqualTo(expectedEndLocation).Using(LatLngComparer.Within(0.000001f)), "Leg.EndLocation");

			Assert.That(currentLeg.Distance, Is.EqualTo(expectedDistance).Using(new ValueTextComparer(StringComparer.InvariantCultureIgnoreCase)), "Leg.Distance");
			Assert.That(currentLeg.Duration, Is.EqualTo(expectedDuration).Using(new ValueTextComparer(StringComparer.InvariantCultureIgnoreCase)), "Leg.Duration");

			Assert.That(currentLeg.Steps.Count(), Is.EqualTo(expectedSteps), "Leg.Steps");

			Assert.That(response.Routes[0].Summary, Is.EqualTo(expectedSummary), "Route.Summary");

			Assert.AreEqual(expectedWaypointStatus, response.Waypoints[0].Status, "Waypoint.Status");
			Assert.AreEqual(expectedWaypointAddressType1, response.Waypoints[1].Types[0], "Waypoint.PlaceType1");
			Assert.AreEqual(expectedWaypointAddressType2, response.Waypoints[1].Types[1], "Waypoint.PlaceType2");
			Assert.AreEqual(expectedWaypointPartialMatch, response.Waypoints[0].PartialMatch, "Waypoint.PartialMatch");
		}



	}
}
