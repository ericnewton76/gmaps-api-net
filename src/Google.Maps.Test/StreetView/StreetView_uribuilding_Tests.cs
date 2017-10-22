using System;
using System.Collections.Generic;

using NUnit.Framework;
using Google.Maps.StreetView;

namespace Google.Maps.Tests.StreetView
{
	[TestFixture]
	public class StreetView_uribuilding_Tests
	{
		Uri gmapsBaseUri = new Uri("http://maps.google.com/");

		[Test]
		public void BasicUri()
		{
			string expected = "/maps/api/streetview?location=30.1,-60.2&size=512x512";

			StreetViewRequest sm = new StreetViewRequest()
			{
				Location = new LatLng(30.1, -60.2)
				,Size = new MapSize(512, 512)
			};

			Uri actualUri = sm.ToUri();
			string actual = actualUri.PathAndQuery;

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void BasicUri_heading()
		{
			string expected = "/maps/api/streetview?location=30.1,-60.2&size=512x512&heading=15";

			StreetViewRequest sm = new StreetViewRequest()
			{
				Location = new LatLng(30.1, -60.2)
				,Size = new MapSize(512, 512)
				,Heading = 15
			};

			Uri actualUri = sm.ToUri();
			string actual = actualUri.PathAndQuery;

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void BasicUri_pitch()
		{
			string expected = "/maps/api/streetview?location=30.1,-60.2&size=512x512&pitch=15";

			StreetViewRequest sm = new StreetViewRequest()
			{
				Location = new LatLng(30.1, -60.2)
				,Size = new MapSize(512, 512)
				,Pitch = 15
			};

			Uri actualUri = sm.ToUri();
			string actual = actualUri.PathAndQuery;

			Assert.AreEqual(expected, actual);
		}
	}
}
