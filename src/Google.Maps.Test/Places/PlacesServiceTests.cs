using System;
using System.Collections.Generic;
using System.Threading;

using NUnit.Framework;

namespace Google.Maps.Places
{
	[TestFixture]
	public class PlacesServiceTests
	{
		GoogleSigned TestingApiKey;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			TestingApiKey = SigningHelper.GetApiKey();
		}

		private PlacesService CreateService()
		{
			return new PlacesService(TestingApiKey);
		}

		[Test]
		public void PlacesTest_Nearby()
		{
			PlacesRequest request = new NearbySearchRequest()
			{
				Location = new LatLng(40.741895, -73.989308),
				Radius = 10000
			};
			PlacesResponse response = CreateService().GetResponse(request);

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);

			// Google requires a delay before resending page token value
			Thread.Sleep(2000);

			// setting the PageToken value should result in valid request
			request = new NearbySearchRequest()
			{
				Location = new LatLng(40.741895, -73.989308),
				Radius = 10000,
				PageToken = response.NextPageToken
			};
			response = CreateService().GetResponse(request);

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);

			// Google requires a delay before resending page token value
			Thread.Sleep(1100);

			// setting an invalid page token should result in InvalidRequest status
			request = new NearbySearchRequest()
			{
				Location = new LatLng(40.741895, -73.989308),
				Radius = 10000,
				PageToken = response.NextPageToken + "A" // invalid token
			};
			response = CreateService().GetResponse(request);

			Assert.AreEqual(ServiceResponseStatus.InvalidRequest, response.Status);
		}

		[Test]
		public void PlacesTest_Text()
		{
			PlacesRequest request = new TextSearchRequest()
			{
				Query = "New York, NY",
				Radius = 10000
			};
			PlacesResponse response = new PlacesService().GetResponse(request);

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);

			// Google requires a delay before resending page token value
			Thread.Sleep(2000);

			// setting the PageToken value should result in valid request
			request = new TextSearchRequest()
			{
				Query = "New York, NY",
				Radius = 10000,
				PageToken = response.NextPageToken
			};
			response = CreateService().GetResponse(request);

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);

			// Google requires a delay before resending page token value
			Thread.Sleep(1100);

			// setting an invalid page token should result in InvalidRequest status
			request = new TextSearchRequest()
			{
				Query = "New York, NY",
				Radius = 10000,
				PageToken = response.NextPageToken + "A" // invalid token
			};
			response = CreateService().GetResponse(request);

			Assert.AreEqual(ServiceResponseStatus.InvalidRequest, response.Status);
		}
	}
}
