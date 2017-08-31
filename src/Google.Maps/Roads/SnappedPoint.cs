using Newtonsoft.Json;

namespace Google.Maps.Roads
{
	[JsonObject(MemberSerialization.OptIn)]
	public class SnappedPoint
	{
		/// <summary>
		/// Contains a latitude and longitude value.
		/// </summary>
		[JsonProperty("location")]
		public SnappedPointLocation Location { get; set; }

		/// <summary>
		/// An integer that indicates the corresponding value in the original request. 
		/// Each value in the request should map to a snapped value in the response. 
		/// However, if you've set interpolate=true, then it's possible that the response will contain more coordinates than the request. 
		/// Interpolated values will not have an originalIndex. These values are indexed from 0, 
		/// so a point with an originalIndex of 4 will be the snapped value of the 5th latitude/longitude passed to the path parameter.
		/// </summary>
		[JsonProperty("originalIndex")]
		public int OriginalIndex { get; set; }

		/// <summary>
		/// A unique identifier for a place. All place IDs returned by the Google Maps Roads API correspond to road segments. 
		/// Place IDs can be used with other Google APIs, including the Google Places API and the Google Maps JavaScript API. 
		/// For example, if you need to get road names for the snapped points returned by the Google Maps Roads API, 
		/// you can pass the placeId to the Google Places API or the Google Maps Geocoding API. Within the Google Maps Roads API, 
		/// you can pass the placeId in a speed limits request to determine the speed limit along that road segment.
		/// </summary>
		/// <see href="https://developers.google.com/maps/documentation/roads/snap#responses"/>
		[JsonProperty("placeId")]
		public string PlaceID { get; set; }

	}
}
