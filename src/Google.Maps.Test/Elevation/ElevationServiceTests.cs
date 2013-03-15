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
	public class ElevationServiceTests
	{
		#region TestFixtureSetup/TearDown
		[TestFixtureSetUp]
		public void FixtureSetup()
		{
			Google.Maps.Internal.Http.Factory = new Google.Maps.Test.Integrations.HttpGetResponseFromResourceFactory("Google.Maps.Test.Elevation");
		}
		[TestFixtureTearDown]
		public void FixtureTearDown()
		{
			Google.Maps.Internal.Http.Factory = new Internal.Http.HttpGetResponseFactory();
		}
		#endregion

		[Test]
		[Ignore("Tolerances problem")]
		public void GetElevationForOneLocation()
		{
			// expectations
			var expectedStatus = ServiceResponseStatus.Ok;
			var expectedResultCount = 1;
			var expectedElevation = 1608.6m;
			var expectedLocation = new LatLng(39.739153, -104.984703);
			
			// test
			var request = new ElevationRequest();

			request.AddLocations(expectedLocation);
			request.Sensor = false;
			var response = new ElevationService().GetResponse(request);

			// asserts
			Assert.AreEqual(expectedStatus, response.Status);
			Assert.AreEqual(expectedResultCount, response.Results.Length);

			Assert.That(expectedElevation, Is.EqualTo(response.Results[0].Elevation).Within(0.1));
			
			Assert.That(expectedLocation, Is.EqualTo(response.Results[0].Location));
		}

		[Test]
		[Ignore("Tolerances problem")]
		public void GetElevationForTwoLocations()
		{
			// expectations
			var expectedStatus = ServiceResponseStatus.Ok;
			var expectedResultCount = 2;

			var expectedElevation1 = 1608.6m;
			var expectedLocation1 = new LatLng(39.739153,-104.984703);
			var expectedElevation2 = -50.789m;
			var expectedLocation2 = new LatLng(36.4555560,-116.8666670);

			// test
			var request = new ElevationRequest();

			request.AddLocations(expectedLocation1, expectedLocation2);
			request.Sensor = false;
			var response = new ElevationService().GetResponse(request);

			// asserts
			Assert.AreEqual(expectedStatus, response.Status);

			Assert.AreEqual(expectedResultCount, response.Results.Length);
			
			Assert.That(expectedElevation1, Is.EqualTo(response.Results[0].Elevation).Within(0.1));
			Assert.That(expectedLocation1, Is.EqualTo(response.Results[0].Location));
			
			Assert.That(expectedElevation2, Is.EqualTo(response.Results[1].Elevation).Within(0.1));
			Assert.That(expectedLocation2, Is.EqualTo(response.Results[1].Location));
		}
	}
}
