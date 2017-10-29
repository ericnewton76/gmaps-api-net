using NUnit.Framework;
using Google.Maps.Common;

namespace Google.Maps
{
	[TestFixture]
	public class MapColorTests
	{
		[Test]
		public void IsUndefined_Works()
		{
			var undefined = new GColor();
			var definedName = GColor.FromName("red");
			var definedRGB = GColor.FromArgb(255,255,255);

			Assert.AreEqual(true, undefined.IsUndefined);
			Assert.AreEqual(false, definedName.IsUndefined);
			Assert.AreEqual(false, definedRGB.IsUndefined);
		}

		[Test]
		public void To24BitColor_Works()
		{
			var namedColor = GColor.FromName("red");
			var rgbColor = GColor.FromArgb(255, 0, 0);
			var rgbaColor = GColor.FromArgb(255, 255, 0, 0);

			Assert.AreEqual("red", namedColor.To24BitColorString());
			Assert.AreEqual("0xFF0000", rgbColor.To24BitColorString());
			Assert.AreEqual("0xFF0000", rgbaColor.To24BitColorString());
		}

		[Test]
		public void To32BitColor_Works()
		{
			var namedColor = GColor.FromName("red");
			var rgbColor = GColor.FromArgb(255, 0, 0);
			var rgbaColor = GColor.FromArgb(255, 255, 0, 0);

			Assert.AreEqual("red", namedColor.To32BitColorString());
			Assert.AreEqual("0xFF0000FF", rgbColor.To32BitColorString());
			Assert.AreEqual("0xFF0000FF", rgbaColor.To32BitColorString());
		}
	}
}