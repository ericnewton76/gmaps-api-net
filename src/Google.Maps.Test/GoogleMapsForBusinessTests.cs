using System.IO;

using NUnit.Framework;

using Google.Maps.Geocoding;

namespace Google.Maps
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
#if NETSTANDARD1
			Assert.Ignore("TODO");
			return null;
#else
			try
			{
				using(var keys = new StreamReader(@"..\..\PrivateSigningKeys.txt"))
				{
					var clientid = keys.ReadLine().Trim();
					var privateKey = keys.ReadLine().Trim();

					return new GoogleSigned(clientid, privateKey);
				}
			}
			catch(FileNotFoundException)
			{
				Assert.Ignore("PrivateSigningKeys.txt could not be found - ignoring test");
				return null;
			}
#endif
		}

		[Test]
		public void Geocoding_Request_Signed_With_Private_Key()
		{
			var request = new GeocodingRequest
			{
				Address = "Stathern, UK"
			};

			GoogleSigned.AssignAllServices(GetRealSigningInstance());
			var response = new GeocodingService().GetResponse(request);

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
		}


		[Test]
		public void Geocoding_Request_Signed_With_Api_Key()
		{
			// Arrange
			var sign = new GoogleSigned("AIzaSyDV-0ftj1tsjfd6GnEbtbxwHXnv6iR3UEU");
			GoogleSigned.AssignAllServices(sign);

			var request = new GeocodingRequest
			{
				Address = "Stathern, UK"
			};

			// Act
			var response = new GeocodingService().GetResponse(request);

			// Assert
			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
		}
	}
}
