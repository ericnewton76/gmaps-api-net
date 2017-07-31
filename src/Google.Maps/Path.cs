using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Google.Maps
{
	public class Path
	{
		public Path()
		{
			Points = new List<Location>();
		}
		public Path(IEnumerable<Location> locations)
		{
			Points = new List<Location>(locations);
		}
		public Path(params Location[] locations)
			: this((IEnumerable<Location>)locations)
		{
		}


		/// <summary>
		/// specifies the thickness of the path in pixels. If no weight parameter is set, the path will appear in its default thickness (5 pixels).
		/// </summary>
		[DefaultValue(5)]
		public int? Weight { get; set; }

		/// <summary>
		/// (optional) specifies a color either as a 24-bit (example: color=0xFFFFCC) or 32-bit hexadecimal value (example: color=0xFFFFCCFF), 
		/// or from the set {black, brown, green, purple, yellow, blue, gray, orange, red, white}.  Default opacity appears to be 50%. 
		/// </summary>
		public MapColor Color { get; set; }

		/// <summary>
		/// indicates both that the path marks off a polygonal area and specifies the fill color to use as an overlay within that area. The 
		/// set of locations following need not be a "closed" loop; the Static Map server will automatically join the first and last points. 
		/// Note, however, that any stroke on the exterior of the filled area will not be closed unless you specifically provide the same 
		/// beginning and end location.
		/// </summary>
		public MapColor FillColor { get; set; }

		/// <summary>
		/// Gets or sets the collection of points for this path
		/// </summary>
		public ICollection<Location> Points { get; set; }

		/// <summary>
		/// Indicates if the paths should be encoded using the Polyline Encoding Algorithm.
		/// </summary>
		/// <remarks>
		/// The library may decide to encode automatically if the number of points is above a certain threshold.
		/// http://code.google.com/apis/maps/documentation/utilities/polylinealgorithm.html
		/// </remarks>
		public bool? Encode { get; set; }

	}
}
