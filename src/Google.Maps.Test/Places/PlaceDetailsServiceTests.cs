using System;
using System.Collections.Generic;

using NUnit.Framework;
using Google.ApiCore;

namespace Google.Maps.Places.Details
{
	[TestFixture]
	class PlaceDetailsServiceTests
	{
		GoogleSigned TestingApiKey;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			TestingApiKey = SigningHelper.GetApiKey();
		}

		private PlaceDetailsService CreateService()
		{
			return new PlaceDetailsService(
				new Internal.MapsHttp(
					new GoogleApiSigningService(
						TestingApiKey
					)
				),
				baseUri: null
			);
		}

		[TestCase("ChIJN1t_tDeuEmsRUsoyG83frY4", "Google")]
		[Test]
		public void PlacesDetailsTest(string placeID, string placeName)
		{
			PlaceDetailsRequest request = new PlaceDetailsRequest()
			{
				PlaceID = placeID
			};
			var response = CreateService().GetResponse(request);

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
			Assert.IsNotNull(response.Result.URL);
			Assert.AreEqual(placeID, response.Result.PlaceID);
			Assert.AreEqual(placeName, response.Result.Name);
		}
	}
}
