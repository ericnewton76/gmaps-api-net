using NUnit.Framework;

namespace Google.Maps
{
	[TestFixture]
	public class MapColorTests
	{
		[Test]
		public void IsUndefined_Works()
		{
			var undefined = new MapColor();
			var definedName = MapColor.FromName("red");
			var definedRGB = MapColor.FromArgb(255,255,255);

			Assert.AreEqual(true, undefined.IsUndefined);
			Assert.AreEqual(false, definedName.IsUndefined);
			Assert.AreEqual(false, definedRGB.IsUndefined);
		}

		[Test]
		public void To24BitColor_Works()
		{
			var namedColor = MapColor.FromName("red");
			var rgbColor = MapColor.FromArgb(255, 0, 0);
			var rgbaColor = MapColor.FromArgb(255, 255, 0, 0);

			Assert.AreEqual("red", namedColor.To24BitColorString());
			Assert.AreEqual("0xFF0000", rgbColor.To24BitColorString());
			Assert.AreEqual("0xFF0000", rgbaColor.To24BitColorString());
		}

		[Test]
		public void To32BitColor_Works()
		{
			var namedColor = MapColor.FromName("red");
			var rgbColor = MapColor.FromArgb(255, 0, 0);
			var rgbaColor = MapColor.FromArgb(255, 255, 0, 0);

			Assert.AreEqual("red", namedColor.To32BitColorString());
			Assert.AreEqual("0xFF0000FF", rgbColor.To32BitColorString());
			Assert.AreEqual("0xFF0000FF", rgbaColor.To32BitColorString());
		}
	}
}