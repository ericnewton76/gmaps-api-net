using System;
using System.Linq;

namespace Google.Maps.Roads
{
	public class SnapToRoadsRequest: BaseRequest
	{
		/// <summary>
		/// The path to be snapped.
		/// </summary>
		/// <see href="https://developers.google.com/maps/documentation/roads/snap#parameter_usage"/>
		public LatLng[] Path { get; set; }

		/// <summary>
		/// Whether to interpolate a path to include all points forming the full road-geometry. 
		/// When true, additional interpolated points will also be returned, 
		/// resulting in a path that smoothly follows the geometry of the road, 
		/// even around corners and through tunnels. Interpolated paths will most likely contain more points than the original path.
		/// </summary>
		/// <see href="https://developers.google.com/maps/documentation/roads/snap#parameter_usage"/>
		public bool Interpolate { get; set; }

		public override Uri ToUri()
		{
			if (Path == null || !Path.Any())
			{
				throw new InvalidOperationException("Path is required");
			}

			var qsb = new Internal.QueryStringBuilder();

			qsb.Append("path", string.Join("|", Path.AsEnumerable()));

			qsb.Append("interpolate", Interpolate ? "true" : "false");

			var url = "snapToRoads?" + qsb;

			return new Uri(url, UriKind.Relative);
		}
	}
}
