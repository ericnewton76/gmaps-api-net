using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Google.Maps.Elevation;
using System.Reflection;

namespace Google.Maps.Test.Elevation
{
	[TestFixture]
	class ElevationRequestTests
	{

		public class ElevationRequestAccessor : ElevationRequest
		{
			#region Accessor goo
			private static Type S_instanceType = typeof(ElevationRequest);
			private static MethodInfo S_ToUriMethod;

			static ElevationRequestAccessor()
			{
				try { S_ToUriMethod = S_instanceType.GetMethod("ToUri", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, new ParameterModifier[] { }); }
				catch { }
				finally { Ensure(S_ToUriMethod, "ToUri"); }
			}

			private static void Ensure(MethodInfo methodInfo, string methodName)
			{
				if (methodInfo == null) Assert.Fail("Method '{0}' on type '{1}' was not found, and the accessor will fail.", methodName, S_instanceType);
			}
#endregion

			public Uri ToUri()
			{
				try
				{
					return (Uri)S_ToUriMethod.Invoke(this, new object[] { });
				}
				catch (TargetInvocationException ex)
				{
					throw ex.InnerException;
				}
			}

		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Sensor_not_set_throws()
		{
			var req = new ElevationRequestAccessor();

			Uri url = req.ToUri();

			Assert.Fail("Expected exception");
		}

		[Test]
		public void GetUrl_one_location()
		{
			var req = new ElevationRequestAccessor();
			req.Sensor = false;
			req.Locations.Add(new LatLng(40.714728, -73.998672));

			string expected = "json?locations=40.714728,-73.998672&sensor=false";
			string actual = req.ToUri().OriginalString;

			Assert.AreEqual(expected, actual);
		}



	}
}
