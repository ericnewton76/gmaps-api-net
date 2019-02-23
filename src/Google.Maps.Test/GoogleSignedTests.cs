using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using NUnit.Framework;

namespace Google.Maps
{
	[TestFixture]
	class GoogleSignedTests
	{

		private const string CLIENT_ID = "gme-YOUR_CLIENT_ID";
		private const string APIKEY = "mykey";
		private const string SHARED_SECRET = "vNIXE0xscrmjlyV-12Nj_BvUPaw=";
		private const string BASE_URI = "https://maps.googleapis.com/maps/api/outputType?sensor=false";
		private const string APPSETTING_KEY = "TestKey";

		private GoogleSigned GetGoogleSigned_TestInstance()
		{
			return new GoogleSigned(CLIENT_ID, SHARED_SECRET);
		}

		[Test]
		public void ctor_ClientId_ForBusiness_Signed()
		{
			//arrange
			var expected = BASE_URI + "&client=" + CLIENT_ID + "&signature=uq9UYD8EJ2JIXvdNGkiMr5FsVdI=";

			//act
			var GoogleSigned = new GoogleSigned(CLIENT_ID, SHARED_SECRET, GoogleSignedType.Business);
			var actual = GoogleSigned.GetSignedUri(BASE_URI);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void ctor_ApiKey()
		{
			//arrange
			string expected = BASE_URI + "&key=" + APIKEY;

			//act
			GoogleSigned sign = new GoogleSigned(APIKEY);
			string actual = sign.GetSignedUri(BASE_URI);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void ctor_ApiKey_And_Signature()
		{
			//arrange
			string expected = BASE_URI + "&key=" + APIKEY + "&signature=ZSPqURu7BsGJ_XybwhRY4kk3Zhg=";

			//act
			GoogleSigned sign = new GoogleSigned(APIKEY, SHARED_SECRET);
			string actual = sign.GetSignedUri(BASE_URI);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		[TestCase("apikey=" + APIKEY,
			BASE_URI + "&key=" + APIKEY)]
		[TestCase("apikey=" + APIKEY + "&secret=" + SHARED_SECRET,
			BASE_URI + "&key=" + APIKEY + "&signature=ZSPqURu7BsGJ_XybwhRY4kk3Zhg=")]
		[TestCase("clientId=" + CLIENT_ID + "&secret=" + SHARED_SECRET,
			BASE_URI + "&client=" + CLIENT_ID + "&signature=uq9UYD8EJ2JIXvdNGkiMr5FsVdI=")]
		public void FromAppSettingsValue_pass(string value, string expected)
		{
			//arrange

			//act
			var signingInstance = GoogleSigned.FromValueString(value);
			var actual = signingInstance.GetSignedUri(BASE_URI);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		[TestCase("")]
		public void FromAppSettingsValue_should_fail(string value)
		{
			Assert.Throws<ArgumentException>(() => {
				var signingInstance = GoogleSigned.FromValueString(value);
				var actual = signingInstance.GetSignedUri(BASE_URI);
			});
		}
	}
}
