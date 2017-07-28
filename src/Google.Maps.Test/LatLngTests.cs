using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Google.Maps
{
	[TestFixture]
	public class LatLngTests
	{
		[Test]
		public void ToString_default_format()
		{
			LatLng latlng = new LatLng(-35.3353m, 95.4454m);

			string expected = "-35.335300,95.445400";
			string actual = latlng.ToString();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		[TestCase(-35.3353d, 95.4454d, "-35.3353,95.4454")]
		[TestCase(40.7142330d, -73.9612910d, "40.714233,-73.961291")]
		[TestCase(0.000001d, -0.000001d, "0.000001,-0.000001")]
		public void GetAsUrlEncoded(double lat, double lng, string expected)
		{
			LatLng latlng = new LatLng(lat, lng);

			//string expected = "-35.335300,95.445400";
			string actual = latlng.GetAsUrlParameter();

			//note, if this test starts failing, it may be because the 'comma' is being (in some circles' opinion) "properly" url encoded to %2c
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Parse_test()
		{
			string value = "40.714224,-73.961452";

			LatLng expected = new LatLng(40.714224m, -73.961452m);
			LatLng actual = LatLng.Parse(value);

			Assert.AreEqual(expected.Latitude, actual.Latitude);
			Assert.AreEqual(expected.Longitude, actual.Longitude);
		}

#if HAS_CURRENTCULTURE
		[Test]
		public void ToString_using_invariant_culture_settings()
		{
			LatLng test = new LatLng(40.714224m, -73.961452m);

			System.Globalization.CultureInfo savedCulture = System.Threading.Thread.CurrentThread.CurrentCulture;

			try
			{
				//change the thread culture
				System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("nl-BE");//belgium uses different numbering

				string expected = "40.714224,-73.961452";
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
			LatLng latLng1 = new LatLng(lat, lng);
			LatLng latLng2 = new LatLng(lat, lng);

			Assert.IsTrue(latLng1.Equals(latLng2), "Equals fails.");
		}

		[Test]
		[TestCase(40.2d, 70.3d)]
		public void NotEquals(double lat, double lng)
		{
			LatLng latLng1 = new LatLng(lat, lng);
			LatLng latLng2 = new LatLng(0d, lng);

			Assert.IsFalse(latLng1.Equals(latLng2));

			LatLng latLng3 = new LatLng(lat, 0d);
			Assert.IsFalse(latLng1.Equals(latLng3));

			LatLng latLng4 = new LatLng(0d, 0d);
			Assert.IsFalse(latLng1.Equals(latLng4));
		}
	}
}
