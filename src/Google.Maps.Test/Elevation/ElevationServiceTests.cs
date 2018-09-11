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

using NUnit.Framework;

namespace Google.Maps.Elevation
{
	[TestFixture]
	public class ElevationServiceTests
	{
		GoogleSigned TestingApiKey;

		ElevationService CreateService()
		{
			var svc = new ElevationService(TestingApiKey);
			return svc;
		}

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			TestingApiKey = SigningHelper.GetApiKey();
		}

		[Test]
		[Category("ValueTesting")]
		public void SHOULD_NOT_RUN()
		{
			Console.WriteLine("SHOULD NOT RUN!!!");
		}


		[Test]
		[Category("ValueTesting")]
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
			var response = CreateService().GetResponse(request);

			if(response.Status == ServiceResponseStatus.OverQueryLimit)
			{
				Assert.Ignore("OverQueryLimit");
			}

			// asserts
			Assert.AreEqual(expectedStatus, response.Status);
			Assert.AreEqual(expectedResultCount, response.Results.Length);

			Assert.That(expectedElevation, Is.EqualTo(response.Results[0].Elevation).Within(0.1));

			Assert.That(expectedLocation, Is.EqualTo(response.Results[0].Location));
		}

		[Test]
		[Category("ValueTesting")]
		public void GetElevationForTwoLocations()
		{
			// expectations
			var expectedStatus = ServiceResponseStatus.Ok;
			var expectedResultCount = 2;

			var expectedElevation1 = 1608.6m;
			var expectedLocation1 = new LatLng(39.739153, -104.984703);
			var expectedElevation2 = -50.789m;
			var expectedLocation2 = new LatLng(36.4555560, -116.8666670);

			// test
			var request = new ElevationRequest();

			request.AddLocations(expectedLocation1, expectedLocation2);
			var response = CreateService().GetResponse(request);


			if(response.Status == ServiceResponseStatus.OverQueryLimit)
			{
				Assert.Ignore("OverQueryLimit");
			}

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
