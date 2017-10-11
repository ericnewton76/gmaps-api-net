using System;
using System.Text.RegularExpressions;

using NUnit.Framework;

namespace Google.Maps.StaticMaps
{
	[TestFixture]
	public class StaticMap_Path_Tests
	{
		[Test]
		public void Points_One()
		{
			var request = new StaticMapRequest();

			LatLng first = new LatLng(30.1, -60.2);
			request.Path = new Path(first);

			string expected = "https://maps.google.com/maps/api/staticmap?size=512x512&path=30.1,-60.2";
			var actual = request.ToUri();

			Assert.AreEqual(expected, actual.ToString());
		}

		[Test]
		public void Points_Two()
		{
			var request = new StaticMapRequest();

			LatLng first = new LatLng(30.1, -60.2);
			LatLng second = new LatLng(40.3, -70.4);

			request.Path = new Path(first, second);

			string expected = "https://maps.google.com/maps/api/staticmap?size=512x512&path=30.1,-60.2|40.3,-70.4";
			var actual = request.ToUri();

			Assert.AreEqual(expected, actual.ToString());
		}

		// The color encoding for google static maps API puts the alpha last (0xrrggbbaa)
		// whereas .NET encodes it alpha first (0xaarrggbb).
		[Test]
		public void Path_NonstandardColor_EncodedProperly()
		{
			var map = new StaticMapRequest();
			map.Paths.Add(new Path(new LatLng(30.0, -60.0))
			{
				Color = MapColor.FromArgb(0x80, 0xA0, 0xC0)
			});
			string color = ExtractColorFromUri(map.ToUri());
			Assert.AreEqual("0X80A0C0FF", color.ToUpper());
		}

		[Test]
		public void Encoded_SinglePoint()
		{
			var request = new StaticMapRequest();

			LatLng zero = new LatLng(30.0, -60.0);
			request.Path = new Path(zero) { Encode = true };

			string expected = "https://maps.google.com/maps/api/staticmap?size=512x512&path=enc:_kbvD~vemJ";
			var actual = request.ToUri();

			Assert.AreEqual(expected, actual.ToString());
		}

		[Test]
		public void TwoPaths()
		{
			var map = new StaticMapRequest();
			map.Paths.Add(GreenTriangleInAdaMN());
			map.Paths.Add(RedTriangleNearAdaMN());

			string expectedPath1 = "&path=color:green|47.3017,-96.5299|47.2949,-96.4999|47.2868,-96.5003|47.3017,-96.5299".Replace("|", "%7C");
			string expectedPath2 = "&path=color:red|47.3105,-96.5326|47.3103,-96.5219|47.3045,-96.5219|47.3105,-96.5326".Replace("|", "%7C");
			string actual = map.ToUri().Query;
			StringAssert.Contains(expectedPath1, actual);
			StringAssert.Contains(expectedPath2, actual);
		}

		private static Path GreenTriangleInAdaMN()
		{
			return new Path(
				new LatLng(47.3017, -96.5299),
				new LatLng(47.2949, -96.4999),
				new LatLng(47.2868, -96.5003),
				new LatLng(47.3017, -96.5299)
			)
			{
				Color =  MapColor.FromName("green")
			};
		}

		private static Path RedTriangleNearAdaMN()
		{
			return new Path(
				new LatLng(47.3105, -96.5326),
				new LatLng(47.3103, -96.5219),
				new LatLng(47.3045, -96.5219),
				new LatLng(47.3105, -96.5326)
			)
			{
				Color = MapColor.FromName("red")
			};
		}

		private static string ExtractColorFromUri(Uri uri)
		{
			var colorMatch = Regex.Match(uri.Query, @"color:([a-z0-9]+)((%7c)|\|)", RegexOptions.IgnoreCase);
			Assert.True(colorMatch.Success, "Could not find color component of path.");
			return colorMatch.Groups[1].Value;
		}

		[Test]
		public void Encode_set_but_not_all_LatLng_positions()
		{
			Assert.Throws<InvalidOperationException>(() =>
			{
				var request = new StaticMapRequest();

				LatLng first = new LatLng(30.0, -60.0);
				Location second = new Location("New York");
				request.Path = new Path(first, second) { Encode = true };

				var actual = request.ToUri();
			});
		}

		[Test]
		public void Implicit_Address_set_from_string()
		{
			var map = new StaticMapRequest();
			map.Center = "New York, NY";

			string expected = "New York, NY";
			string actual = map.Center.ToString();

			Assert.AreEqual(expected, actual);
		}
	}
}