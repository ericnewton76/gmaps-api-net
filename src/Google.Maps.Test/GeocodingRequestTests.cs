using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Google.Maps.Geocoding;
using System.Reflection;

namespace Google.Maps.Test
{
    [TestFixture]
    public class GeocodingRequestTests
    {


        public class GeocodingRequestAccessor
        {
            private GeocodingRequest _instance = new GeocodingRequest();

            private static Type S_instanceType;
            private static MethodInfo _GetBoundsStr;

            static GeocodingRequestAccessor()
            {
                S_instanceType = typeof(GeocodingRequest);
                _GetBoundsStr = S_instanceType.GetMethod("GetBoundsStr", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(Viewport) }, new ParameterModifier[] { });
				Ensure(_GetBoundsStr, "GetBoundsStr");
            }

			private static void Ensure(MethodInfo methodInfo, string methodName)
			{
				if (methodInfo == null) Assert.Fail("Method '{0}' on type '{1}' was not found, and the accessor will fail.", methodName, S_instanceType);
			}

            public string GetBoundsStr(Viewport bounds)
            {
                try
                {
                    return (string)_GetBoundsStr.Invoke(_instance, new object[] { bounds });
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            }
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


    }
}
