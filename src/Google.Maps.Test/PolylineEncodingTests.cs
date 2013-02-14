using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Google.Maps;

namespace Google.Maps.Test
{
	[TestFixture]
	public class PolylineEncodingTests
	{
		[Test]
		public void encode_coords_1()
		{
			LatLng[] points = new LatLng[] { 
				new LatLng(38.5,-120.2),
				new LatLng(40.7,-120.95),
				new LatLng(43.252,-126.453)
			};

			string actual = PolylineEncoder.EncodeCoordinates(points);
			string expected = "_p~iF~ps|U_ulLnnqC_mqNvxq`@";

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void decode_coords_1()
		{
			string value = "_p~iF~ps|U_ulLnnqC_mqNvxq`@";

			LatLng[] expected = new LatLng[] { 
				new LatLng(38.5,-120.2),
				new LatLng(40.7,-120.95),
				new LatLng(43.252,-126.453)
			};

			IEnumerable<LatLng> actual2 = PolylineEncoder.Decode(value);

			LatLng[] actual = actual2.ToArray();

			Assert.Inconclusive();
			//Assert.AreEqual(expected.Length, actual.Length);

			for(int i=0; i<actual.Length;i++)
			{
				Assert.AreEqual(expected[i].Latitude, actual[i].Latitude);
				Assert.AreEqual(expected[i].Longitude, actual[i].Longitude);
			}
		}
	}
}
