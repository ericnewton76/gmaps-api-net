using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Maps.Test
{
	[TestFixture]
	public class ValueTextComparer_Tests
	{

		private ValueTextComparer CreateComparer()
		{
			return new ValueTextComparer(StringComparer.OrdinalIgnoreCase);
		}
		private ValueText CreateValueText(string text="Text", long value = 0)
		{
			return new ValueText() { Text = text, Value = value };
		}

		[Test]
		public void ctor_Throw_ArgumentNull_when_null_passed()
		{
			//arrange


			//act

			//assert
			Assert.Throws<ArgumentNullException>(() =>
			{
				var comparer = new ValueTextComparer(null);
			});
		}

		[Test]
		public void Compare_right_is_null_returns_positive()
		{
			//arrange
			var comparer = CreateComparer();
			ValueText left = CreateValueText();
			ValueText right = null;

			//act
			var actual = comparer.Compare(left, right);

			//assert
			Assert.That(actual, Is.GreaterThan(0));
		}

		[Test]
		public void Compare_left_is_null_returns_neg()
		{
			//arrange
			var comparer = CreateComparer();
			ValueText left = null;
			ValueText right = CreateValueText();

			//act
			var actual = comparer.Compare(left, right);

			//assert
			Assert.That(actual, Is.LessThan(0));
		}

		[Test]
		public void Compare_tests_equal1()
		{
			//arrange
			var comparer = CreateComparer();
			ValueText left = CreateValueText();
			ValueText right = CreateValueText();

			//act
			var actual = comparer.Compare(left, right);

			//assert
			Assert.That(actual, Is.EqualTo(0));
		}

	}
}
