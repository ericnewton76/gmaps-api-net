using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Google.Maps.Elevation;
using System.Reflection;

namespace Google.Maps.Test.Elevation
{
	[TestFixture]
	class ElevationRequestTests
	{
		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Sensor_not_set_throws()
		{
			var req = new ElevationRequest();

			Uri url = req.ToUri();

			Assert.Fail("Expected exception");
		}

		[Test]
		public void GetUrl_one_location()
		{
			var req = new ElevationRequest();
			req.Sensor = false;
			req.Locations.Add(new LatLng(40.714728, -73.998672));

			string expected = "json?locations=40.714728,-73.998672&sensor=false";
			string actual = req.ToUri().OriginalString;

			Assert.AreEqual(expected, actual);
		}



	}
}
