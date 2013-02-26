using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Google.Maps.Geocoding;
using Google.Maps.StaticMaps;

namespace Google.Maps.Test
{
	/*
	 *  This test fixture was set up to ensure that the online samples work as written and as expected.
	 */
	[TestFixture]
	[Explicit()]
	[Category("External Integrations")]
	class QuickExamplesTests
	{

		[Test]
		public void GeocodingRequest_Example()
		{
			var request = new GeocodingRequest();
			request.Address = "1600 Amphitheatre Parkway";
			request.Sensor = false;
			var response = new GeocodingService().GetResponse(request);

			// --break in the online version here-- //

			var result = response.Results.First();

			Console.WriteLine("Full Address: " + result.FormattedAddress);         // "1600 Amphitheatre Pkwy, Mountain View, CA 94043, USA"
			Console.WriteLine("Latitude: " + result.Geometry.Location.Latitude);   // 37.4230180
			Console.WriteLine("Longitude: " + result.Geometry.Location.Longitude); // -122.0818530

			Assert.Pass();
		}

		[Test]
		public void StaticMapRequest_Example()
		{
			var map = new StaticMapRequest();
			map.Center = new Location("1600 Amphitheatre Parkway Mountain View, CA 94043");
			map.Size = new System.Drawing.Size(400, 400);
			map.Zoom = 14;
			map.Sensor = false;

			var imgTagSrc = map.ToUri();

			Assert.Pass();
		}

	}
}
