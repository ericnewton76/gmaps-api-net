using System;

using NUnit.Framework;
using Google.Maps.StreetView;

namespace Google.Maps.StreetView
{
	[TestFixture]
	public class StreetViewRequestTests
	{
		[Test]
		public void Invalid_size_propert_set()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				StreetViewRequest sm = new StreetViewRequest()
				{
					Size = new MapSize(-1, -1)
				};
			});
		}

		[Test]
		public void Invalid_size_max()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				StreetViewRequest sm = new StreetViewRequest()
				{
					Size = new MapSize(4097, 4097)
				};
			});
		}

		[Test]
		[TestCase(-91)]
		[TestCase(91)]
		public void Pitch_argumentoutofrange(short badvalue)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				StreetViewRequest sm = new StreetViewRequest()
				{
					Pitch = badvalue
				};
			});
		}

		[Test]
		[TestCase(121)]
		[TestCase(-1)]
		[TestCase(0)]
		public void FieldOfView_argumentoutofrange(short badvalue)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				StreetViewRequest sm = new StreetViewRequest()
				{
					FieldOfView = badvalue
				};
			});
		}

		[Test]
		[TestCase(-1)]
		[TestCase(361)]
		public void Heading_argumentoutofrange(short badvalue)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				StreetViewRequest sm = new StreetViewRequest()
				{
					Heading = badvalue
				};
			});
		}


	}
}
