using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Google.Maps;

namespace Google.Maps.Test
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
		public void GetAsUrlEncoded()
		{
			LatLng latlng = new LatLng(-35.3353m, 95.4454m);

			string expected = "-35.335300,95.445400";
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

    }
}
