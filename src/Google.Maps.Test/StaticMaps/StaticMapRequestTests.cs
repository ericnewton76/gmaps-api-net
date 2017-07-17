using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Google.Maps.StaticMaps;

using System.Reflection;
using Google.Maps;
using System.Text.RegularExpressions;

namespace Google.Maps.Test.StaticMaps
{
    [TestFixture]
    public class StaticMapRequestTests
    {

        

        [Test]
        public void Invalid_size_propert_set()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new StaticMapRequest()
                {
                    Sensor = false,
                    Size = new System.Drawing.Size(-1, -1)
                }
            );
        }

        [Test]
        public void Invalid_size_max()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new StaticMapRequest()
                {
                    Sensor = false,
                    Size = new System.Drawing.Size(4097, 4097)
                }
            );
        }


        [Test]
        public void Zoom_argumentoutofrange_bottom()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new StaticMapRequest()
                {
                    Sensor = false,
                    Zoom = -1
                }
            );
        }
        [Test]
        public void Zoom_setbacktonull()
        {
            StaticMapRequest sm = new StaticMapRequest()
            {
                Zoom = 1
            };
            sm.Zoom = null;

            Assert.Pass();
        }

        [Test]
        public void Scale_argumentoutofrange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            new StaticMapRequest()
            {
                Scale = 3
            });
        }

        //needs RowTest extension here.
        [Test]
        public void Scale_validvalue_1()
        {
            StaticMapRequest sm = new StaticMapRequest()
            {
                Scale = 1
            };

            Assert.AreEqual(1, sm.Scale);
        }
        [Test]
        public void Scale_validvalue_2()
        {
            StaticMapRequest sm = new StaticMapRequest()
            {
                Scale = 2
            };

            Assert.AreEqual(2, sm.Scale);
        }
        [Test]
        public void Scale_validvalue_4()
        {
            StaticMapRequest sm = new StaticMapRequest()
            {
                Scale = 4
            };

            Assert.AreEqual(4, sm.Scale);
        }

		[Test]
		public void Markers_ShouldNotUseExtraZeros_BecauseUrlLengthIsLimited()
		{
			StaticMapRequest map = new StaticMapRequest();
			map.Markers.Add(new LatLng(40.0, -60.0));
			map.Markers.Add(new LatLng(41.1, -61.1));
			map.Markers.Add(new LatLng(42.22, -62.22));
			map.Markers.Add(new LatLng(44.444, -64.444));
			map.Markers.Add(new LatLng(45.5555, -65.5555));
			map.Markers.Add(new LatLng(46.66666, -66.66666));
			map.Markers.Add(new LatLng(47.777777, -67.777777));
			map.Markers.Add(new LatLng(48.8888888, -68.8888888));
			// based on this http://gis.stackexchange.com/a/8674/15274,
			// I'm not too concerned about more than 7 decimals of precision.

			string actual = map.ToUri().Query;
			StringAssert.Contains("markers=40,-60&", actual);
			StringAssert.Contains("markers=41.1,-61.1&", actual);
			StringAssert.Contains("markers=42.22,-62.22&", actual);
			StringAssert.Contains("markers=44.444,-64.444&", actual);
			StringAssert.Contains("markers=45.5555,-65.5555&", actual);
			StringAssert.Contains("markers=46.66666,-66.66666&", actual);
			StringAssert.Contains("markers=47.777777,-67.777777&", actual);
			StringAssert.Contains("markers=48.8888888,-68.8888888", actual);
		}

    }

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
				Color = System.Drawing.Color.FromArgb(0x80, 0xA0, 0xC0)
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
                Color = System.Drawing.Color.Green
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
                Color = System.Drawing.Color.Red
            }; ;
        }

        private static string ExtractColorFromUri(Uri uri)
        {
            var colorMatch = Regex.Match(uri.Query, @"color:([a-z0-9]+)((%7c)|\|)", RegexOptions.IgnoreCase);
            Assert.True(colorMatch.Success, "Could not find color component of path.");
            return colorMatch.Groups[1].Value;
        }

		[Test]
		//[ExpectedException(typeof(InvalidOperationException))]
		public void Encode_set_but_not_all_LatLng_positions()
		{
			var request = new StaticMapRequest();

			LatLng first = new LatLng(30.0, -60.0);
			Location second = new Location("New York");
			request.Path = new Path(first, second) { Encode = true };

			Assert.Throws<InvalidOperationException>(() => request.ToUri());
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
