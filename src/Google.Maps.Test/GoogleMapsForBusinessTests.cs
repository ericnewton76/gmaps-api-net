using System.IO;

using NUnit.Framework;

using Google.Maps.Geocoding;

namespace Google.Maps.Test
{
	/*
	 * These tests require a real Google Maps for Business Client ID and Signing key.
	 * This information should be stored in the PrivateSigningKeys.txt file, with the
	 * Client ID on line 1, and the Signing Key on line 2.
	 * 
	 * The .gitignore prevents this file from being checked into GitHub :)
	 * 
	 * If this file does not exist then the tests will do an Assert.Ignore
	 */

	[TestFixture]
	[Explicit()]
	[Category("External Integrations")]
	class GoogleMapsForBusinessTests
	{
		private GoogleSigned GetRealSigningInstance()
		{
			try
			{
				using (var keys = new StreamReader(@"..\..\PrivateSigningKeys.txt"))
				{
					var clientid = keys.ReadLine().Trim();
					var privateKey = keys.ReadLine().Trim();

					return new GoogleSigned(clientid, privateKey);
				}
			}
			catch (FileNotFoundException)
			{
				Assert.Ignore("PrivateSigningKeys.txt could not be found - ignoring test");
				return null;
			}
		}

		[Test]
		public async void Signed_GeocodingRequest_Works()
		{
			var request = new GeocodingRequest
			{
				Address = "Stathern, UK",
				Sensor = false
			};

			GoogleSigned.AssignAllServices(GetRealSigningInstance());
            var response = await new GeocodingService().GetResponseAsync(request);

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
		}
	}
}
