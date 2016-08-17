using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps.Places.Details
{
	public class PlaceDetailsResponse
	{
		/// <summary>
		/// Contains the ServiceResponseStatus.
		/// </summary>
		[JsonProperty("status")]
		public ServiceResponseStatus Status { get; set; }

		/// <summary>
		/// Contains the error returned from the API, if any.
		/// </summary>
		[JsonProperty("error_message")]
		public string ErrorMessage { get; set; }

		/// <summary>
		/// The results returned from the API, if any.
		/// </summary>
		[JsonProperty("result")]
		public PlaceDetailsResult Result { get; set; }
	}
}
