using Google.Maps.Places;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Google.Maps.Test.Places
{
	[TestFixture]
	public class PlacesServiceTests
	{
		[Test]
		public void PlacesTest_Nearby()
		{
			PlacesRequest request = new NearbySearchRequest()
			{
				Location = new LatLng(40.741895, -73.989308),
				Radius = 10000,
				Sensor = false
			};
			PlacesResponse response = new PlacesService().GetResponse(request);

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);

			// Google requires a delay before resending page token value
			Thread.Sleep(2000);

			// setting the PageToken value should result in valid request
			request = new NearbySearchRequest()
			{
				Location = new LatLng(40.741895, -73.989308),
				Radius = 10000,
				Sensor = false,
				PageToken = response.NextPageToken
			};
			response = new PlacesService().GetResponse(request);

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);

			// Google requires a delay before resending page token value
			Thread.Sleep(1100);

			// setting an invalid page token should result in InvalidRequest status
			request = new NearbySearchRequest()
			{
				Location = new LatLng(40.741895, -73.989308),
				Radius = 10000,
				Sensor = false,
				PageToken = response.NextPageToken + "A" // invalid token
			};
			response = new PlacesService().GetResponse(request);

			Assert.AreEqual(ServiceResponseStatus.InvalidRequest, response.Status);
		}

		[Test]
		public void PlacesTest_Text()
		{
			PlacesRequest request = new TextSearchRequest()
			{
				Query = "New York, NY",
				Radius = 10000,
				Sensor = false
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
				Sensor = false,
				PageToken = response.NextPageToken
			};
			response = new PlacesService().GetResponse(request);

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);

			// Google requires a delay before resending page token value
			Thread.Sleep(1100);

			// setting an invalid page token should result in InvalidRequest status
			request = new TextSearchRequest()
			{
				Query = "New York, NY",
				Radius = 10000,
				Sensor = false,
				PageToken = response.NextPageToken + "A" // invalid token
			};
			response = new PlacesService().GetResponse(request);

			Assert.AreEqual(ServiceResponseStatus.InvalidRequest, response.Status);
		}

		[SetUp]
		public void PlaceSetUp()
		{
			GoogleSigned signingInstance = Utility.GetRealSigningInstance();
			GoogleSigned.AssignAllServices(signingInstance);
		}
	}
}
