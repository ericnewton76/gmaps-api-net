using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Google.Maps.Test
{
	[TestFixture] 
	class GoogleSignedTests
	{

		private GoogleSigned GetGoogleSigned_TestInstance()
		{
			return new GoogleSigned("gme-YOUR_CLIENT_ID", "vNIXE0xscrmjlyV-12Nj_BvUPaw=");
		}

		[Test]
		public void SignedUrl_1()
		{
			GoogleSigned sign = GetGoogleSigned_TestInstance();

			var uri = "http://testserver/maps/api/outputType?sensor=false";
			uri += "client=" + sign.ClientId;

			string expected = "nEt2lIqwIuMkMia4OtJhsCc8cT0=";
			string actual = sign.GetSignature(uri);

			Assert.AreEqual(expected, actual);
		}

	}
}
