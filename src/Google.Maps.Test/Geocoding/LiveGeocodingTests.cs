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
using System.Linq;
using System.Text;

using Google.Maps.Geocoding;

using NUnit.Framework;

namespace Google.Maps.Test.Geocoding
{
	[TestFixture]
	[Explicit()]
	[Category("External Integrations")]
	public class LiveGeocodingTests
	{
		[Test]
		public async void Geocode_With_AddressComponent_Locking()
		{
			var requestGB = new GeocodingRequest
			{
				Address = "Boston",
				Sensor = false,
				Components = "country:GB"
			};

			var requestUS = new GeocodingRequest
			{
				Address = "Boston",
				Sensor = false,
				Components = "country:US"
			};

			var responseGB = await new GeocodingService().GetResponseAsync(requestGB);
            var responseUS = await new GeocodingService().GetResponseAsync(requestUS);

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
        public async void Geocode_Without_AddressComponent_Locking()
		{
			var request = new GeocodingRequest
			{
				Address = "Boston",
				Sensor = false
			};

            var response = await new GeocodingService().GetResponseAsync(request);

			foreach (var r in response.Results)
			{
				Assert.IsTrue(r.FormattedAddress.EndsWith("USA"));
			}
		}

		[Test]
        public async void GeocodeResult_Has_BoundsProperty()
		{
			var request = new GeocodingRequest
			{
				Address = "Boston",
				Sensor = false
			};

            var response = await new GeocodingService().GetResponseAsync(request);

			Assert.IsNotNull(response.Results[0].Geometry.Bounds);
			Assert.IsNotNull(response.Results[0].Geometry.Bounds.Southwest);
			Assert.IsNotNull(response.Results[0].Geometry.Bounds.Northeast);
		}

		[Test]
        public async void GeocodeResult_Supports_PostalTownAndPostalCodePrefix()
		{
			var request = new GeocodingRequest
			{
				Address = "Stathern, UK",
				Sensor = false
			};

            var response = await new GeocodingService().GetResponseAsync(request);

			var postalTown = response.Results[0].AddressComponents.First(x => x.ShortName == "Melton Mowbray");
			Assert.IsFalse(postalTown.Types.Contains(AddressType.Unknown), postalTown.ShortName + " should be AddressType PostalTown");

			var postalCodePrefix = response.Results[0].AddressComponents.First(x => x.ShortName == "LE14");
			Assert.IsFalse(postalCodePrefix.Types.Contains(AddressType.Unknown), postalCodePrefix.ShortName + " should be AddressType PostalCodePrefix");
		}
	}
}
