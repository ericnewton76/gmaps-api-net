using System;
using System.Collections.Generic;

using NUnit.Framework;
using Google.Maps.StreetView;
using FluentAssertions.Collections;
using FluentAssertions;

namespace Google.Maps.Tests.StreetView
{
	[TestFixture]
	public class StreetView_uribuilding_Tests
	{
		Uri gmapsBaseUri = new Uri("http://maps.google.com/");

		private Dictionary<string,string> ParseQueryString(string querystring)
		{
			Dictionary<string, string> values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

			int indexOfQmark = querystring.IndexOf("?");

			if(indexOfQmark>-1)
			{
				querystring = querystring.Substring(indexOfQmark + 1);
			}

			string[] kvpairs = querystring.Split('&');
			foreach(var keyequalvalue in kvpairs)
			{
				string[] kv = keyequalvalue.Split('=');
				values[kv[0]] = kv[1];

			}

			return values;
		}


		[Test]
		public void BasicUri()
		{
			//arrange
			var expected = ParseQueryString("/maps/api/streetview?location=30.1,-60.2&size=512x512");
			
			StreetViewRequest sm = new StreetViewRequest()
			{
				Location = new LatLng(30.1, -60.2)
				,Size = new MapSize(512, 512)
			};

			//act
			Uri actualUri = sm.ToUri();
			var actual = ParseQueryString(actualUri.PathAndQuery);

			//assert
			actual.ShouldAllBeEquivalentTo(expected);
		}

		[Test]
		public void BasicUri_heading()
		{
			//arrange
			var expected = ParseQueryString("/maps/api/streetview?location=30.1,-60.2&size=512x512&heading=15");

			StreetViewRequest sm = new StreetViewRequest()
			{
				Location = new LatLng(30.1, -60.2)
				,Size = new MapSize(512, 512)
				,Heading = 15
			};

			//act
			Uri actualUri = sm.ToUri();
			var actual = ParseQueryString(actualUri.PathAndQuery);

			//assert
			actual.ShouldAllBeEquivalentTo(expected);
		}

		[Test]
		public void BasicUri_pitch()
		{
			//arrange
			var expected = ParseQueryString("/maps/api/streetview?location=30.1,-60.2&size=512x512&pitch=15");

			StreetViewRequest sm = new StreetViewRequest()
			{
				Location = new LatLng(30.1, -60.2)
				,Size = new MapSize(512, 512)
				,Pitch = 15
			};

			//act
			Uri actualUri = sm.ToUri();
			var actual = ParseQueryString(actualUri.PathAndQuery);

			//assert
			actual.ShouldAllBeEquivalentTo(expected);
		}

	}
}
