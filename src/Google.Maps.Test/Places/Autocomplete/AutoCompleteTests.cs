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
				Input = "London",
				Licencekey = "AIzaSyA5e-MpZ89-Sy-P8ZAG1-BS6kc--88IghI"
			};

			var service = new PlacesService();
			AutocompleteResponse response = null;

			response = service.GetAutocompleteResponse(request);

			Assert.IsNotNull(response);
		}

	}
}
