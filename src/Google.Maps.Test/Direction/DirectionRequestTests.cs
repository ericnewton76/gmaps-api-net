using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Google.Maps.Geocoding;
using System.Reflection;
using Google.Maps.Direction;

namespace Google.Maps.Test
{
	[TestFixture]
	public class DirectionRequestTests
	{


		public class DirectionRequestAccessor
		{
			private DirectionRequest _instance = new DirectionRequest();

			private static Type S_instanceType;
			private static MethodInfo _ToUri;

			static DirectionRequestAccessor()
			{
				S_instanceType = typeof(DirectionRequest);

				try { _ToUri = S_instanceType.GetMethod("ToUri", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, new ParameterModifier[] { }); }
				catch { }
				finally { Ensure(_ToUri, "ToUri"); }
			}

			private static void Ensure(MethodInfo methodInfo, string methodName)
			{
				if (methodInfo == null) Assert.Fail("Method '{0}' on type '{1}' was not found, and the accessor will fail.", methodName, S_instanceType);
			}

			#region Protected/Private interface
			public Uri ToUri()
			{
				try
				{
					return (Uri)_ToUri.Invoke(_instance, new object[] { });
				}
				catch (TargetInvocationException ex)
				{
					throw ex.InnerException;
				}
			}
			#endregion

			#region Public interface copy
			public Waypoint Origin 
			{ 
				get { return this._instance.Origin; } 
				set { this._instance.Origin = value; } 
			}
			public Waypoint Destination 
			{ 
				get { return this._instance.Destination; } 
				set { this._instance.Destination = value; } 
			}

			#endregion

		}

		//[Test]
		//[ExpectedException(typeof(InvalidOperationException))]
		//public void Viewport_has_properties_notset()
		//{
		//    Viewport bounds = new Viewport();

		//    GeocodingRequestAccessor request=new GeocodingRequestAccessor();

		//    string actual = request.GetBoundsStr(bounds);
		//    string expected = "Expected an InvalidOperationException because viewport has a null northeast and southwest properties"; //expecting an exception

		//    Assert.Fail(expected);
		//}


		//[Test]
		//public void GetBoundsStr()
		//{
		//    Viewport bounds = new Viewport() { Southwest = new LatLng(30.0, -40.0), Northeast = new LatLng(40.0, -30.0) };

		//    GeocodingRequestAccessor request = new GeocodingRequestAccessor();

		//    string actual = request.GetBoundsStr(bounds);
		//    string expected = "30.000000,-40.000000%7C40.000000,-30.000000";

		//    Assert.AreEqual(expected, actual);
		//}

		//[Test]
		//[NUnit.Framework.SetCulture("ar-MA")]//set to arabic because of the multitude of cultural format changes
		//public void GetBoundsStr_uses_invariant()
		//{
		//    Viewport bounds = new Viewport() { Southwest = new LatLng(30.0, -40.0), Northeast = new LatLng(40.0, -30.0) };

		//    GeocodingRequestAccessor request = new GeocodingRequestAccessor();

		//    string actual = request.GetBoundsStr(bounds);
		//    string expected = "30.000000,-40.000000%7C40.000000,-30.000000";

		//    Assert.AreEqual(expected, actual);
		//}


		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetUrl_sensor_not_set_should_throw_error()
		{
			var req = new DirectionRequestAccessor();
			//req.Origin = "New York, NY";

			var actual = req.ToUri();

			Assert.Fail("Should've encountered an InvalidOperationException due to Sensor property not being set.");
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetUrl_no_Address_set()
		{
			var req = new DirectionRequestAccessor();
			//req.Address = something;

			var actual = req.ToUri();

			Assert.Fail("Should've encountered an InvalidOperationException due to Address property not being set.");
		}
	}
}
