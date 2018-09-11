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

namespace Google.Maps.Direction
{
	[TestFixture]
	class DirectionServiceTests 
	{
		GoogleSigned TestingApiKey;

		DirectionService CreateService()
		{
			var svc = new DirectionService(TestingApiKey);
			return svc;
		}

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			TestingApiKey = SigningHelper.GetApiKey();
		}

		[Test]
		[Category("ValueTesting")]
		public void Empty_Address_Fails()
		{
			Assert.Throws<HttpRequestException>(() =>
			{
				// Arrange
				var request = new DirectionRequest { Origin = "" };

				// Act
				var response = CreateService().GetResponse(request);
			});
		}

		[Test]
		[Category("ValueTesting")]
		public void GetResultForDirections_ex1()
		{
			// Arrange
			var request = new DirectionRequest
			{
				Origin = "21 Henr St, Bristol, UK", // Typo intended so that it produces a partial match
				Destination = "27 Victoria Drive, Lyneham"
			};

			// Act
			var response = CreateService().GetResponse(request);

			// Assert
			if(response.Status == ServiceResponseStatus.OverQueryLimit)
			{
				Assert.Ignore("OverQueryLimit");
			}
			
			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status, "Status");
			Assert.AreEqual(1, response.Routes.Length, "ResultCount");

			var currentLeg = response.Routes[0].Legs[0];

			Assert.AreEqual("21 Henry St, Bristol BS3 4UD, UK", currentLeg.StartAddress);
			Assert.That(currentLeg.StartLocation, Is.EqualTo(new LatLng(51.442,-2.579)).Using(LatLngComparer.Within(0.001f)));

			Assert.AreEqual("27 Victoria Dr, Lyneham, Chippenham SN15 4RA, UK", currentLeg.EndAddress);
			Assert.That(currentLeg.EndLocation, Is.EqualTo(new LatLng(51.505,-1.958)).Using(LatLngComparer.Within(0.001f)));

			Assert.That(currentLeg.Distance.Value, Is.EqualTo(53939));
			Assert.That(currentLeg.Duration.Value, Is.EqualTo(2956));

			Assert.AreEqual(19, currentLeg.Steps.Count());

			Assert.AreEqual("M4", response.Routes[0].Summary);

			Assert.AreEqual(2, response.Waypoints.Length);
			Assert.AreEqual(ServiceResponseStatus.Ok, response.Waypoints[0].Status);
			Assert.AreEqual(AddressType.StreetAddress, response.Waypoints[0].Types[0]);
			Assert.AreEqual(true, response.Waypoints[0].PartialMatch);

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Waypoints[1].Status);
			Assert.AreEqual(AddressType.StreetAddress, response.Waypoints[1].Types[0]);
			Assert.AreEqual(false, response.Waypoints[1].PartialMatch);
		}
	}
}
