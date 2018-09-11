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
using System.Collections.Generic;

using NUnit.Framework;

namespace Google.Maps.TimeZone
{
	public class TimeZoneServiceTests
	{
		GoogleSigned TestingApiKey;

		TimeZoneService CreateService()
		{
			var svc = new TimeZoneService(TestingApiKey);
			return svc;
		}

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			TestingApiKey = SigningHelper.GetApiKey();
		}

		[Test]
		[Category("ValueTesting")]
		public void TimeZoneService_Works_During_DST()
		{
			// Arrange
			var request = new TimeZoneRequest
			{
				Location = new LatLng(52.8723, 0.8551),
				Timestamp = new DateTime(2017, 6, 13)
			};

			// Act
			var response = CreateService().GetResponse(request);

			if(response.Status == ServiceResponseStatus.OverQueryLimit)
			{
				Assert.Ignore("OverQueryLimit");
			}

			// Assert
			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
			Assert.AreEqual("Europe/London", response.TimeZoneID);
			Assert.AreEqual("British Summer Time", response.TimeZoneName);
			Assert.AreEqual(3600, response.DstOffSet);
		}

		[Test]
		[Category("ValueTesting")]
		public void TimeZoneService_Works_Outside_DST()
		{
			// Arrange
			var request = new TimeZoneRequest
			{
				Location = new LatLng(52.8723, 0.8551),
				Timestamp = new DateTime(2017, 1, 1)
			};

			// Act
			var response = CreateService().GetResponse(request);

			if(response.Status == ServiceResponseStatus.OverQueryLimit)
			{
				Assert.Ignore("OverQueryLimit");
			}

			// Assert
			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
			Assert.AreEqual("Europe/London", response.TimeZoneID);
			Assert.AreEqual("Greenwich Mean Time", response.TimeZoneName);
			Assert.AreEqual(0, response.DstOffSet);
		}
	}
}
