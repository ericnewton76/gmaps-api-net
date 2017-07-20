using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Google.Maps
{
	[TestFixture]
	public class LocationTests
	{
		[Test]
		public void GetAsUrlEncoded()
		{
			Location l = new Location("City Hall, New York, NY");

			string expected = "City%20Hall%2C%20New%20York%2C%20NY";
			string actual = l.GetAsUrlParameter();

			//note, if this test starts failing, it may be because the 'comma' is being (in some circles' opinion) "properly" url encoded to %2c
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Location_tostring()
		{
			Location l = new Location("Somewhereville");

			string expected = "Somewhereville";
			string actual = l.ToString();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Location_implicit_string()
		{
			Location l = "City Hall, New York, NY";

			string expected = "City Hall, New York, NY";
			string actual = l.ToString();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Location_with_spaces_gives_empty_url()
		{
			Location l = "    ";

			string expected = "";
			string actual = l.GetAsUrlParameter();

			Assert.AreEqual(expected, actual);
		}
	}
}
