using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Google.Maps.StaticMaps
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
