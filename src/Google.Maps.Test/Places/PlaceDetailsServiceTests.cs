using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Google.Maps.Places.Details
{
	[TestFixture]
	class PlaceDetailsServiceTests
	{
		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			GoogleSigned.AssignAllServices(SigningHelper.GetApiKey());
		}

		[TestCase("ChIJN1t_tDeuEmsRUsoyG83frY4", "Google")]
		[Test]
		[Category("ValueTesting")]
		public void PlacesDetailsTest(string placeID, string placeName)
		{
			PlaceDetailsRequest request = new PlaceDetailsRequest()
			{
				PlaceID = placeID
			};
			var response = new PlaceDetailsService().GetResponse(request);

			if(response.Status == ServiceResponseStatus.OverQueryLimit)
			{
				Assert.Ignore("OverQueryLimit");
			}

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
			Assert.IsNotNull(response.Result.URL);
			Assert.AreEqual(placeID, response.Result.PlaceID);
			Assert.AreEqual(placeName, response.Result.Name);
		}
	}
}
