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
using System.Net;
using Google.Api.Maps.Service.Elevation;
using NUnit.Framework;

namespace Google.Api.Maps.Service.Test
{
	[TestFixture]
	public class ElevationServiceTests
	{
		[Test]
		[ExpectedException(typeof(WebException))]
		public void GetElevationWithoutParameters()
		{
			// test
            var request = new ElevationRequest(String.Empty, String.Empty);
			var response = ElevationService.GetResponse(request);
		}

		[Test]
		public void GetElevationForOneLocation()
		{
			// expectations
			var expectedStatus = ServiceResponseStatus.Ok;
			var expectedResultCount = 1;
			var expectedElevation = 1608.8402100m;
			var expectedLocationLatitude = 39.7391536m;
			var expectedLocationLongitude = -104.9847034m;
			
			// test
            var coordinates = "39.7391536,-104.9847034";
            var request = new ElevationRequest(coordinates, "false");
			var response = ElevationService.GetResponse(request);

			// asserts
			Assert.AreEqual(expectedStatus, response.Status);
			Assert.AreEqual(expectedResultCount, response.Results.Length);
			Assert.AreEqual(expectedElevation, response.Results.Single().Elevation);
			Assert.AreEqual(expectedLocationLatitude, response.Results.Single().Location.Latitude);
			Assert.AreEqual(expectedLocationLongitude, response.Results.Single().Location.Longitude);
		}

		[Test]
		public void GetElevationForTwoLocations()
		{
			// expectations
			var expectedStatus = ServiceResponseStatus.Ok;
			var expectedResultCount = 2;
			var expectedElevation1 = 1608.8402100m;
			var expectedLocationLatitude1 = 39.7391536m;
			var expectedLocationLongitude1 = -104.9847034m;
			var expectedElevation2 = -50.7890358m;
			var expectedLocationLatitude2 = 36.4555560m;
			var expectedLocationLongitude2 = -116.8666670m;

			// test
            var locations = "39.7391536,-104.9847034|36.455556,-116.866667";
            var request = new ElevationRequest(locations, "false");
			var response = ElevationService.GetResponse(request);

			// asserts
			Assert.AreEqual(expectedStatus, response.Status);
			Assert.AreEqual(expectedResultCount, response.Results.Length);
			Assert.AreEqual(expectedElevation1, response.Results.First().Elevation);
			Assert.AreEqual(expectedLocationLatitude1, response.Results.First().Location.Latitude);
			Assert.AreEqual(expectedLocationLongitude1, response.Results.First().Location.Longitude);
			Assert.AreEqual(expectedElevation2, response.Results.Last().Elevation);
			Assert.AreEqual(expectedLocationLatitude2, response.Results.Last().Location.Latitude);
			Assert.AreEqual(expectedLocationLongitude2, response.Results.Last().Location.Longitude);
		}
	}
}
