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
using System.Net;
using NUnit.Framework;
using Google.Maps.Elevation;

namespace Google.Maps.Test.Elevation
{
	[TestFixture]
	[Explicit()]
	[Category("External Integrations")]
	public class ElevationServiceTests
	{
		[Test]
		[ExpectedException(typeof(WebException))]
		public void GetElevationWithoutParameters()
		{
			// test
			var request = new ElevationRequest();
			var response = ElevationService.GetResponse(request);
		}

		[Test]
		public void GetElevationForOneLocation()
		{
			// expectations
			var expectedStatus = ServiceResponseStatus.Ok;
			var expectedResultCount = 1;
			var expectedElevation = 1608.6m;
			var expectedLocation = new LatLng(39.739153, -104.984703);
			
			// test
			var request = new ElevationRequest();
			request.Locations = "39.7391536,-104.9847034";
			request.Sensor = "false";
			var response = ElevationService.GetResponse(request);

			// asserts
			Assert.AreEqual(expectedStatus, response.Status);
			Assert.AreEqual(expectedResultCount, response.Results.Length);

			Assert.That(expectedElevation, Is.EqualTo(response.Results[0].Elevation).Within(0.09), "Result.Elevation");

			Assert.That(expectedLocation, Is.EqualTo(response.Results[0].Location).Using(LatLngComparer.Within(0.000001f)), "Result.Location");
		}

		[Test]
		public void GetElevationForTwoLocations()
		{
			// expectations
			var expectedStatus = ServiceResponseStatus.Ok;
			var expectedResultCount = 2;
			var expectedElevation1 = 1608.6m;
			var expectedLocation1 = new LatLng(39.739153,-104.984703);
			var expectedElevation2 = -50.8m;
			var expectedLocation2 = new LatLng(36.4555560, -116.866667);

			// test
			var request = new ElevationRequest();
			request.Locations = "39.7391536,-104.9847034|36.455556,-116.866667";
			request.Sensor = "false";
			var response = ElevationService.GetResponse(request);

			// asserts
			Assert.AreEqual(expectedStatus, response.Status);
			Assert.AreEqual(expectedResultCount, response.Results.Length, "Results.Length");

			Assert.That(expectedElevation1, Is.EqualTo(response.Results[0].Elevation).Within(0.09), "Results[0].Elevation");
			Assert.That(expectedLocation1, Is.EqualTo(response.Results[0].Location).Using(LatLngComparer.Within(0.000001f)), "Results[0].Location");

			Assert.AreEqual(expectedElevation2, Is.EqualTo(response.Results[1].Elevation).Within(0.09), "Results[1].Elevation");
			Assert.AreEqual(expectedLocation2, Is.EqualTo(response.Results[1].Location).Using(LatLngComparer.Within(0.000001f)), "Results[1].Location");

		}
	}
}
