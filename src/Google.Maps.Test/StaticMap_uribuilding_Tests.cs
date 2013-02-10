using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Maps.StaticMaps;
using Google.Maps;
using NUnit.Framework;

namespace Google.Maps.Test
{
    [TestFixture]
    public class StaticMap_uribuilding_Tests
    {
        Uri gmapsBaseUri = new Uri("http://maps.google.com/");

        [Test]
        public void BasicUri()
        {
			StaticMapRequest sm = new StaticMapRequest()
            {
                Sensor = false,
                Center = new LatLng(30.0, -90.0)
            };

            Uri actual = sm.ToUri();
            Uri actualRelative = actual.MakeRelativeUri(gmapsBaseUri);

			Uri expected = new Uri("/maps/api/json");

			Assert.Inconclusive();
        }
    }
}
