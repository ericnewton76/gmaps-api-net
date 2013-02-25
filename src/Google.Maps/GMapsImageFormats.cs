using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Maps
{
	/// <summary>
	/// Represents the different image formats available from the Google Maps API.
	/// </summary>
	public enum GMapsImageFormats
	{
		Unspecified = 0,
		/// <summary>
		/// (default) specifies the 8-bit PNG format
		/// </summary>
		PNG = 1,
		/// <summary>
		/// specifies the 8-bit PNG format
		/// </summary>
		PNG8 = 1,
		/// <summary>
		/// specifies the 32-bit PNG format
		/// </summary>
		PNG32 = 2,
		/// <summary>
		/// specifies the GIF format
		/// </summary>
		GIF = 4,
		/// <summary>
		/// specifies the JPEG compression format
		/// </summary>
		JPG = 5,
		/// <summary>
		/// specifies a non-progressive JPEG compression format
		/// </summary>
		JPGbaseline = 6
	}
}
