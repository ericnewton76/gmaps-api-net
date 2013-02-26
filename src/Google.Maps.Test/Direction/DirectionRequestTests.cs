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


		public class DirectionRequestAccessor : DirectionRequest
		{
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
					return (Uri)_ToUri.Invoke(this, new object[] { });
				}
				catch (TargetInvocationException ex)
				{
					throw ex.InnerException;
				}
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

			var actual = req.ToUri();

			Assert.Fail("Should've encountered an InvalidOperationException due to Sensor property not being set.");
		}

		//TODO: enable this [Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetUrl_no_Origin_set()
		{
			var req = new DirectionRequestAccessor();
			//req.Origin = nothing basically;

			var actual = req.ToUri();

			Assert.Fail("Should've encountered an InvalidOperationException due to Origin property not being set.");
		}

		//TODO: enable this [Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetUrl_no_Destination_set()
		{
			var req = new DirectionRequestAccessor();
			//req.Origin = nothing basically;

			var actual = req.ToUri();

			Assert.Fail("Should've encountered an InvalidOperationException due to Destination property not being set.");
		}

		[Test]
		public void GetUrl_simplest_using_address_ex1()
		{
			var req = new DirectionRequestAccessor();
			req.Sensor = false;
			req.Origin = "New York, NY";
			req.Destination = "Albany, NY";
			req.Mode = TravelMode.driving; //this is default, so querystring doesn't need to contain it.

			Uri expected = new Uri("json?origin=New+York,+NY&destination=Albany,+NY&sensor=false", UriKind.Relative);
			Uri actual = req.ToUri();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GetUrl_simplest_using_latlng()
		{
			var req = new DirectionRequestAccessor();
			req.Sensor = false;
			req.Origin = new LatLng(30.2, 40.3);
			req.Destination = new LatLng(50.5,60.6);
			req.Mode = TravelMode.driving; //this is default, so querystring doesn't need to contain it.

			Uri expected = new Uri("json?origin=30.2,40.3&destination=50.5,60.6&sensor=false", UriKind.Relative);
			Uri actual = req.ToUri();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GetUrl_waypoints_simple_ex1()
		{
			var req = new DirectionRequestAccessor();
			req.Sensor = false;
			req.Origin = "NY";
			req.Destination = "FL";
			req.Mode = TravelMode.driving; //this is default, so querystring doesn't need to contain it.

			req.AddWaypoint("NC");

			Uri expected = new Uri("json?origin=NY&destination=FL&waypoints=NC&sensor=false", UriKind.Relative);
			Uri actual = req.ToUri();

			Assert.AreEqual(expected, actual);

		}

		[Test]
		public void GetUrl_waypoints_latlng_ex1()
		{
			var req = new DirectionRequestAccessor();
			req.Sensor = false;
			req.Origin = "NY";
			req.Destination = "Orlando,FL";
			req.Mode = TravelMode.driving; //this is default, so querystring doesn't need to contain it.

			req.AddWaypoint(new LatLng(28.452694, -80.979195));

			Uri expected = new Uri("json?origin=NY&destination=Orlando,FL&waypoints=28.452694,-80.979195&sensor=false", UriKind.Relative);
			Uri actual = req.ToUri();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GetUrl_waypoints_latlng_ex2()
		{
			var req = new DirectionRequestAccessor();
			req.Sensor = false;
			req.Origin = "NY";
			req.Destination = "Orlando,FL";
			req.Mode = TravelMode.driving; //this is default, so querystring doesn't need to contain it.

			req.AddWaypoint("NJ");
			req.AddWaypoint(new LatLng(28.452694, -80.979195));
			req.AddWaypoint("Sarasota,FL");

			Uri expected = new Uri("json?origin=NY&destination=Orlando,FL&waypoints=NJ|28.452694,-80.979195|Sarasota,FL&sensor=false", UriKind.Relative);
			Uri actual = req.ToUri();

			Assert.AreEqual(expected, actual);
		}



	}
}
