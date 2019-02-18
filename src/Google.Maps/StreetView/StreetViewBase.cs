namespace Google.Maps.StreetView
{
	public abstract class StreetViewBase : BaseRequest
	{
		/// <summary>
		/// Defines the center of the map, equidistant from all edges of the
		/// map. This parameter takes an <see cref="Location" />-derived instance identifying a
		/// unique location on the face of the earth. Use <see cref="LatLng" /> for a
		/// {latitude,longitude} pair (e.g. 40.714728,-73.998672) or use <see cref="Location" /> for a
		/// string address (e.g. "city hall, new york, ny"). Either Location or PanoramaId is required.
		/// </summary>
		public Location Location { get; set; }

		/// <summary>
		/// PanoramaId is a specific panorama ID. These are generally stable.
		/// Either Location or PanoramaId is required.
		/// </summary>
		public string PanoramaId { get; set; }
	}
}