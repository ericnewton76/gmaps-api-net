using System.Linq;
using NUnit.Framework;
using Google.Api.Maps.Service.Geocoding;

namespace Google.Api.Maps.Test
{
    [TestFixture]
    public class GoogleMapsTests
    {
        [Test]
        public void FindLocationByName()
        {
            var gmaps = new GoogleMaps();
            var r = gmaps.FindLocation("viamonte 1621, capital federal").FirstOrDefault();

            var expectedStreet = "Viamonte";
            var expectedNumber = "1621";
            var expectedCity = "San Nicolás";

            Assert.AreEqual(expectedStreet, r.Components.HavingType(AddressType.Route).FirstOrDefault().LongName);
            Assert.AreEqual(expectedNumber, r.Components.HavingType(AddressType.StreetNumber).FirstOrDefault().LongName);
            Assert.AreEqual(expectedCity, r.Components.HavingType(AddressType.Neighborhood).FirstOrDefault().LongName);
        }

        [Test]
        public void FindAddress()
        {
            var gmaps = new GoogleMaps();
            var r = gmaps.FindAddress("viamonte 1621, capital federal");

        }
    }
}
