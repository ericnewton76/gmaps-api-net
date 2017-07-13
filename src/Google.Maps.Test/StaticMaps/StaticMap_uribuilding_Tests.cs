using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Maps.StaticMaps;
using Google.Maps;
using NUnit.Framework;

namespace Google.Maps.Test.StaticMaps
{
	[TestFixture]
	public class StaticMap_uribuilding_Tests
	{
		Uri gmapsBaseUri = new Uri("http://maps.google.com/");

		[Test]
		public void BasicUri()
		{
			string expected = "/maps/api/staticmap?center=30.1,-60.2&size=512x512";

			StaticMapRequest sm = new StaticMapRequest()
			{
				Center = new LatLng(30.1, -60.2)
			};

			Uri actualUri = sm.ToUri();
			string actual = actualUri.PathAndQuery;

			Assert.AreEqual(expected, actual);
		}
	}
}
