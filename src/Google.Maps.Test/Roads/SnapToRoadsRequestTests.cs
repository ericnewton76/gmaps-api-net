using NUnit.Framework;

namespace Google.Maps.Roads
{
	[TestFixture]
	public class SnapToRoadsRequestTests
	{
		[Test]
		public void RequestGeneratesCorrectUri()
		{
			var req = new SnapToRoadsRequest
			{
				Path = new[] {new LatLng(1.0, 1.0), new LatLng(2.0, 2.0)}
			};

			var uri = req.ToUri();
			Assert.AreEqual(uri.ToString(), "snapToRoads?path=1.000000,1.000000|2.000000,2.000000&interpolate=false");
		}

		[Test]
		public void RequestGeneratesUriWithInterpolation()
		{
			var req = new SnapToRoadsRequest
			{
				Path = new[] { new LatLng(1.0, 2.0), new LatLng(3.0, 4.0) },
				Interpolate = true
			};

			var uri = req.ToUri();
			Assert.AreEqual(uri.ToString(), "snapToRoads?path=1.000000,2.000000|3.000000,4.000000&interpolate=true");
		}
	}
}
