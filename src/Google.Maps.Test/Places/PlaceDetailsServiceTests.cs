using Google.Maps.Places.Details;
using NUnit.Framework;

namespace Google.Maps.Test.Places
{
    [TestFixture]
    class PlaceDetailsServiceTests
    {
        [TestCase("ChIJN1t_tDeuEmsRUsoyG83frY4", "Google")]
        [Test]
        public void PlacesDetailsTest(string placeID, string placeName)
        {
            PlaceDetailsRequest request = new PlaceDetailsRequest()
            {
                PlaceID = placeID
            };
            var response = new PlaceDetailsService().GetResponse(request);

            Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
            Assert.IsNotNull(response.Result.URL);
            Assert.AreEqual(placeID, response.Result.PlaceID);
            Assert.AreEqual(placeName, response.Result.Name);
        }

        [SetUp]
        public void PlaceDetailsSetUp()
        {
            GoogleSigned signingInstance = Utility.GetRealSigningInstance();
            GoogleSigned.AssignAllServices(signingInstance);
        }
    }

}
