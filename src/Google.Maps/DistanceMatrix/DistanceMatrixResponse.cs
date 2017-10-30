using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Google.Maps.Common;

namespace Google.Maps.DistanceMatrix
{
	/// <summary>
	///
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	public class DistanceMatrixResponse : IServiceResponse
	{
		/// <summary>
		/// Contains the ServiceResponseStatus.
		/// </summary>
		[JsonProperty("status")]
		public ServiceResponseStatus Status { get; set; }

		/// <summary>
		/// More detailed information about the reasons behind the given status code, if other than OK.
		/// </summary>
		[JsonProperty("error_message")]
		public string ErrorMessage { get; set; }

		[JsonProperty("destination_addresses")]
		public string[] DestinationAddresses { get; set; }

		[JsonProperty("origin_addresses")]
		public string[] OriginAddresses { get; set; }

		[JsonProperty("rows")]
		public DistanceMatrixRows[] Rows { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonObject(MemberSerialization.OptIn)]
		public class DistanceMatrixRows
		{
			[JsonProperty("elements")]
			public DistanceMatrixElement[] Elements { get; set; }
		}//end class

		/// <summary>
		///
		/// </summary>
		[JsonObject(MemberSerialization.OptIn)]
		public class DistanceMatrixElement
		{

			[JsonProperty("status")]
			public ServiceResponseStatus Status { get; set; }

			[JsonProperty("distance")]
			public ValueText distance { get; set; }

			[JsonProperty("duration")]
			public ValueText duration { get; set; }
		}//end class
	}//end class
}//end namespace
