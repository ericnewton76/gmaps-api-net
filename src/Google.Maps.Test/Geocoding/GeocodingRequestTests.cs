using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Google.Maps.Geocoding;
using System.Reflection;

namespace Google.Maps.Test
{
	[TestFixture]
	public class GeocodingRequestTests
	{
		//[Test]
		//[ExpectedException(typeof(InvalidOperationException))]
		//public void Viewport_has_properties_notset()
		//{
		//    Viewport bounds = new Viewport();

		//    GeocodingRequestAccessor request=new GeocodingRequestAccessor();

		//    string actual = request.GetBoundsStr(bounds);
		//    string expected = "Expected an InvalidOperationException because viewport has a null northeast and southwest properties"; //expecting an exception

		//    Assert.Fail(expected);
		//}


		//[Test]
		//public void GetBoundsStr()
		//{
		//    Viewport bounds = new Viewport() { Southwest = new LatLng(30.0, -40.0), Northeast = new LatLng(40.0, -30.0) };

		//    GeocodingRequestAccessor request = new GeocodingRequestAccessor();

		//    string actual = request.GetBoundsStr(bounds);
		//    string expected = "30.000000,-40.000000%7C40.000000,-30.000000";

		//    Assert.AreEqual(expected, actual);
		//}

		//[Test]
		//[NUnit.Framework.SetCulture("ar-MA")]//set to arabic because of the multitude of cultural format changes
		//public void GetBoundsStr_uses_invariant()
		//{
		//    Viewport bounds = new Viewport() { Southwest = new LatLng(30.0, -40.0), Northeast = new LatLng(40.0, -30.0) };

		//    GeocodingRequestAccessor request = new GeocodingRequestAccessor();

		//    string actual = request.GetBoundsStr(bounds);
		//    string expected = "30.000000,-40.000000%7C40.000000,-30.000000";

		//    Assert.AreEqual(expected, actual);
		//}

		[Test]
		public void Implicit_Address_set_from_string()
		{
			var req = new GeocodingRequest();
			req.Address = "New York, NY";

			string expected = "New York, NY";
			string actual = req.Address.ToString();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void LatLng_for_address_will_invoke_reverse_geocoding()
		{
			var req = new GeocodingRequest();

			req.Address = new LatLng(-30.1d, 40.2d); //using -30.1f,40.2f gives precision error beyond 6 digits when using format "R". strange.

			Uri expected = new Uri("json?latlng=-30.1,40.2", UriKind.Relative);
			Uri actual = req.ToUri();

			Assert.AreEqual(expected, actual);
		}

		public void GetUrl_no_Address_set()
		{
			var req = new GeocodingRequest();
			//req.Address = something;

			var actual = req.ToUri();

			Assert.Fail("Should've encountered an InvalidOperationException due to Address property not being set.");
		}
	}
}
