using Google.Maps.Places.Details;
using NUnit.Framework;

namespace Google.Maps.Test.Places
{
    [TestFixture]
    class PlaceDetailsServiceTests
    {
        [Test]
        public void PlacesDetailsTest()
        {
            PlaceDetailsRequest request = new PlaceDetailsRequest()
            {
                PlaceID = "ChIJN1t_tDeuEmsRUsoyG83frY4"
            };
            var response = new PlaceDetailsService().GetResponse(request);

            Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
        }

        [SetUp]
        public void PlaceDetailsSetUp()
        {
            GoogleSigned signingInstance = Utility.GetRealSigningInstance();
            GoogleSigned.AssignAllServices(signingInstance);
        }
    }

}
