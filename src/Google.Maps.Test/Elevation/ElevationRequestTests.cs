using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Google.Maps.Elevation
{
	[TestFixture]
	class ElevationRequestTests
	{
		[Test]
		public void GetUrl_one_location()
		{
			var req = new ElevationRequest();
			req.Locations.Add(new LatLng(40.714728, -73.998672));

			string expected = "json?locations=40.714728,-73.998672";
			string actual = req.ToUri().OriginalString;

			Assert.AreEqual(expected, actual);
		}
	}
}
