using Google.Maps.Common;
using Newtonsoft.Json;

namespace Google.Maps.Roads
{
	[JsonObject(MemberSerialization.OptIn)]
	public class SnapToRoadsResponse : IServiceResponse
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
	
		[JsonProperty("snappedPoints")]
		public SnappedPoint[] SnappedPoints { get; set; }
	}
}