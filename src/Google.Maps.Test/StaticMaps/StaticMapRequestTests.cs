using System;

using NUnit.Framework;

namespace Google.Maps.StaticMaps
{
	[TestFixture]
	public class StaticMapRequestTests
	{
		[Test]
		public void Invalid_size_propert_set()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				StaticMapRequest sm = new StaticMapRequest()
				{
					Size = new MapSize(-1, -1)
				};
			});
		}

		[Test]
		public void Invalid_size_max()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				StaticMapRequest sm = new StaticMapRequest()
				{
					Size = new MapSize(4097, 4097)
				};
			});
		}

		[Test]
		public void Zoom_argumentoutofrange_bottom()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				StaticMapRequest sm = new StaticMapRequest()
				{
					Zoom = -1
				};
			});
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
			{
				StaticMapRequest sm = new StaticMapRequest()
				{
					Scale = 3
				};
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
}
