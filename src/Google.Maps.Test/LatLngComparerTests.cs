using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Google.Maps
{
	[TestFixture]
	class LatLngComparerTests
	{
		[Test]
		public void Ex_1_precision()
		{
			LatLng expected = new LatLng(30.3, 40.4);

			LatLng actual = new LatLng(30.31, 40.41);

			Assert.That(expected, Is.EqualTo(actual).Using(LatLngComparer.Within(0.1f)));
		}

		[Test]
		public void Ex_6_precision()
		{
			LatLng expected = new LatLng(30.343434, 40.412121);

			LatLng actual = new LatLng(30.34343400001, 40.41212100001);

			Assert.That(expected, Is.EqualTo(actual).Using(LatLngComparer.Within(0.000001f)));
		}
	}
}
