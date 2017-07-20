using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Google.Maps
{
	[TestFixture]
	class GoogleSignedTests
	{
		private GoogleSigned GetGoogleSigned_TestInstance()
		{
			return new GoogleSigned("gme-YOUR_CLIENT_ID", "vNIXE0xscrmjlyV-12Nj_BvUPaw=");
		}

		[Test]
		public void Private_Key_Signing()
		{
			GoogleSigned sign = GetGoogleSigned_TestInstance();

			var uri = "http://testserver/maps/api/outputType?sensor=false";
			uri += "client=" + sign.ClientId;

			string expected = "nEt2lIqwIuMkMia4OtJhsCc8cT0=";
			string actual = sign.GetSignature(uri);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Api_Key_Signing()
		{
			var sign = new GoogleSigned("mykey");

			string signed = sign.GetSignedUri("http://a/dummy/server?a=b");

			Assert.AreEqual("http://a/dummy/server?a=b&key=mykey", signed);
		}
	}
}
