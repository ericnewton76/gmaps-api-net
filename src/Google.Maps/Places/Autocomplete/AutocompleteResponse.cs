using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using Google.Maps.Common;

namespace Google.Maps.Places
{
	public class AutocompleteResponse
	{
		[JsonProperty("status")]
		public ServiceResponseStatus Status { get; set; }

		[JsonProperty("error_message")]
		public string ErrorMessage { get; set; }

		[JsonProperty("predictions")]
		public AutocompleteResult[] Predictions { get; set; }
	}
}
