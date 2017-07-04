using System;
using NUnit.Framework;
using Google.Maps.Places;

namespace Google.Maps.Test.Places.Autocomplete
{
	[TestFixture]
	public class AutoCompleteTests
	{
		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void ExceptionIsThrownIfApikeyIsNotProvided()
		{
			var request = new AutocompleteRequest()
			{
				Sensor = false,
				Input = "London"
			};

			var	response = new PlacesService().GetAutocompleteResponse(request);

		}
		
		[Test]
		public void ResponseIsNotNull()
		{
			var request = new AutocompleteRequest()
			{
				Sensor = false,
				Input = "London"
			};

			var service = new PlacesService();
			AutocompleteResponse response = null;

			response = service.GetAutocompleteResponse(request);

			Assert.IsNotNull(response);
		}

		[Test]
		public void ResponseWith_Types_And_Places()
		{
			var request = new AutocompleteRequest()
			{
				Sensor = false,
				Input = "SK4 5DA",
				Regions = true,
				Components = "UK"
			};

			var service = new PlacesService();
			AutocompleteResponse response = null;

			response = service.GetAutocompleteResponse(request);

			Assert.IsNotNull(response);
			Assert.IsTrue(response.Predictions.Length > 0);
			Assert.IsTrue(response.Status == ServiceResponseStatus.Ok);
		}

	}
}
