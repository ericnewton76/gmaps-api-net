using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Google.Maps.StaticMaps;

using System.Reflection;
using Google.Maps;

namespace Google.Maps.Test
{
	[TestFixture]
	public class StaticMapRequestTests
	{

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Sensor_not_set_throws_invalidoperationexception_when_touri_called()
		{
			StaticMapRequest sm = new StaticMapRequest();
			sm.ToUri();

			Assert.Fail("InvalidOPerationException was expected");
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Invalid_size_propert_set()
		{
			StaticMapRequest sm = new StaticMapRequest()
			{
				Sensor = false,
				Size = new System.Drawing.Size(-1, -1)
			};

			Assert.Fail("Invalid size was set to property but no exception happened.");
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Invalid_size_max()
		{
			StaticMapRequest sm = new StaticMapRequest()
			{
				Sensor = false,
				Size = new System.Drawing.Size(4097, 4097)
			};

			Assert.Fail("Invalid size was set to property but no exception happened.");
		}


		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Zoom_argumentoutofrange_bottom()
		{
			StaticMapRequest sm = new StaticMapRequest()
			{
				Sensor = false,
				Zoom = -1
			};

			Assert.Fail("Zoom was set to invalid value.");
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
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Scale_argumentoutofrange()
		{
			StaticMapRequest sm = new StaticMapRequest()
			{
				Scale = 3
			};

			Assert.Fail("Expected an ArgumentOutOfRange exception.");
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


	}

	[TestFixture]
	public class StaticMap_Path_Tests
	{
		public class StaticMapRequestAccessor
		{
			private StaticMapRequest _instance = new StaticMapRequest();
			private Type _instanceType = typeof(StaticMapRequest);

			public new string GetPathsStr()
			{
				MethodInfo method = _instanceType.GetMethod("GetPathsStr", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, new ParameterModifier[] { });

				try
				{
					return (string)method.Invoke(_instance, new object[] { });
				}
				catch (TargetInvocationException ex)
				{
					throw ex.InnerException;
				}
			}
			public Path Path { get { return _instance.Path; } set { this._instance.Path = value; } }
		}

		[Test]
		public void Points_One()
		{
			StaticMapRequestAccessor accessor = new StaticMapRequestAccessor();

			LatLng first = new LatLng(30.1, -60.2);
			accessor.Path = new Path(first);

			string expected = "path=30.1,-60.2";
			string actual = accessor.GetPathsStr();

			Assert.AreEqual(expected, actual);
		}
		[Test]
		public void Points_Two()
		{
			StaticMapRequestAccessor accessor = new StaticMapRequestAccessor();

			LatLng first = new LatLng(30.1, -60.2);
			LatLng second = new LatLng(40.3, -70.4);

			accessor.Path = new Path(first, second);

			string expected = "path=30.1,-60.2%7C40.3,-70.4";
			string actual = accessor.GetPathsStr();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Encoded_SinglePoint()
		{
			StaticMapRequestAccessor accessor = new StaticMapRequestAccessor();

			LatLng zero = new LatLng(30.0, -60.0);
			accessor.Path = new Path(zero) { Encode = true };

			string expected = "path=enc:" + PolylineEncoder.EncodeCoordinates(new LatLng[] { zero });
			string actual = accessor.GetPathsStr();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Encode_set_but_not_all_LatLng_positions()
		{
			StaticMapRequestAccessor accessor = new StaticMapRequestAccessor();

			LatLng first = new LatLng(30.0, -60.0);
			Location second = new Location("New York");
			accessor.Path = new Path(first, second) { Encode = true };

			string expected = null;//expecting an Exception
			string actual = accessor.GetPathsStr();

			Assert.Fail("Expected an InvalidOperationException because first point was LatLng but second point was Location.");
		}

		[Test]
		public void Online_Sample_Works()
		{
			//NOTE: changes here should be reflected on the project wiki at http://code.google.com/p/gmaps-api-net/
			var map = new StaticMapRequest();
			map.Center = new Location("1600 Amphitheatre Parkway Mountain View, CA 94043");
			map.Size = new System.Drawing.Size(400, 400);
			map.Zoom = 14;
			map.Sensor = false;

			Assert.Ignore();
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
