using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Google.Maps
{
	[TestFixture]
	public class ViaLatLngTests
	{
		[Test]
		public void ToString_default_format()
		{
			ViaLatLng ViaLatLng = new ViaLatLng(-35.3353m, 95.4454m);

			string expected = "via:-35.335300,95.445400";
			string actual = ViaLatLng.ToString();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		[TestCase(-35.3353d, 95.4454d, "via:-35.3353,95.4454")]
		[TestCase(40.7142330d, -73.9612910d, "via:40.714233,-73.961291")]
		public void GetAsUrlEncoded(double lat, double lng, string expected)
		{
			ViaLatLng ViaLatLng = new ViaLatLng(lat, lng);

			//string expected = "via:-35.335300,95.445400";
			string actual = ViaLatLng.GetAsUrlParameter();

			//note, if this test starts failing, it may be because the 'comma' is being (in some circles' opinion) "properly" url encoded to %2c
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Parse_test()
		{
			string value = "40.714224,-73.961452";

			ViaLatLng expected = new ViaLatLng(40.714224m, -73.961452m);
			ViaLatLng actual = ViaLatLng.Parse(value);

			Assert.AreEqual(expected.Latitude, actual.Latitude);
			Assert.AreEqual(expected.Longitude, actual.Longitude);
		}

#if HAS_CURRENTCULTURE
		[Test]
		public void ToString_using_invariant_culture_settings()
		{
			ViaLatLng test = new ViaLatLng(40.714224m, -73.961452m);

			System.Globalization.CultureInfo savedCulture = System.Threading.Thread.CurrentThread.CurrentCulture;

			try
			{
				//change the thread culture
				System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("nl-BE");//belgium uses different numbering

				string expected = "via:40.714224,-73.961452";
				string actual = test.ToString();

				Assert.AreEqual(expected, actual);
			}
			finally
			{
				System.Threading.Thread.CurrentThread.CurrentCulture = savedCulture;
			}
		}
#endif

		[Test]
		[TestCase(30.1d, 60.2d)]
		public void Equals(double lat, double lng)
		{
			ViaLatLng ViaLatLng1 = new ViaLatLng(lat, lng);
			ViaLatLng ViaLatLng2 = new ViaLatLng(lat, lng);

			Assert.IsTrue(ViaLatLng1.Equals(ViaLatLng2), "Equals fails.");
		}

		[Test]
		[TestCase(40.2d, 70.3d)]
		public void NotEquals(double lat, double lng)
		{
			ViaLatLng ViaLatLng1 = new ViaLatLng(lat, lng);
			ViaLatLng ViaLatLng2 = new ViaLatLng(0d, lng);

			Assert.IsFalse(ViaLatLng1.Equals(ViaLatLng2));

			ViaLatLng ViaLatLng3 = new ViaLatLng(lat, 0d);
			Assert.IsFalse(ViaLatLng1.Equals(ViaLatLng3));

			ViaLatLng ViaLatLng4 = new ViaLatLng(0d, 0d);
			Assert.IsFalse(ViaLatLng1.Equals(ViaLatLng4));
		}
	}
}
