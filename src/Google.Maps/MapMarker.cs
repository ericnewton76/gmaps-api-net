using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Google.Maps
{

	/// <summary>
	/// Represents a set of location markers to be drawn on a map with certain style properties.
	/// </summary>
	public class MapMarkers
	{
		public MapMarkers()
		{
			Locations = new List<Location>();
		}

		/// <summary>
		/// Creates a MapMarkers instance with the given Locations.
		/// </summary>
		/// <param name="locations"></param>
		public MapMarkers(params Location[] locations)
		{
			Locations = new List<Location>(locations);
		}


		/// <summary>
		/// Gets or sets the size of marker from the set {tiny, mid, small}. If no size parameter is set, the marker will appear in its default (normal) size. (optional)
		/// </summary>
		public MarkerSizes MarkerSize { get; set; }


		/// <summary>
		/// Gets or sets the label for the markers.  This specifies a single uppercase alphanumeric character from the set {A-Z, 0-9}. (The requirement for uppercase characters is new to the 3.7 version of the API.)
		/// Note that default and mid sized markers are the only markers capable of displaying an alphanumeric-character parameter. tiny and small markers are not capable of displaying an alphanumeric-character.
		/// (optional)
		/// </summary>
		public string Label { get; set; }


		/// <summary>
		/// Gets or sets the color for the markers.  This property specifies a 24-bit color (example: color=0xFFFFCC)
		/// or a predefined color from the set {black, brown, green, purple, yellow, blue, gray, orange, red, white}.
		/// (optional)
		/// </summary>
		public MapColor Color { get; set; }


		/// <summary>
		/// Gets the collection of Locations for the current style of map markers.
		/// </summary>
		public ICollection<Location> Locations { get; set; }


		/// <summary>
		/// Gets or sets the URL for the icon.  This specifies a URL to use as the marker's custom icon.
		/// Images may be in PNG, JPEG or GIF formats, though PNG is recommended.
		/// (optional)
		/// </summary>
		/// <remarks>
		/// The icon parameter must be specified using a URL (which should be URL-encoded). You may use any valid URL
		/// of your choosing, or a URL-shortening service such as http://bit.ly or http://tinyurl.com. Most URL-shortening
		/// services have the advantage of automatically encoding URLs. Icons are limited to sizes of 4096 pixels (64x64 for square images),
		/// and the Static Maps service allows up to five unique custom icons per request. Note that each of these unique icons
		/// may be used multiple times within the static map. Custom icons that have a shadow:true descriptor (the default) will have
		/// their "anchor point" set as the bottom center of the provided icon image, from which the shadow is cast. Icons without
		/// a shadow (setting a shadow:false descriptor) are instead assumed to be icons centered on their specified locations,
		/// so their anchor points are set as the center of the image.
		/// </remarks>
		public string IconUrl { get; set; }

		/// <summary>
		/// Gets or sets the flag for building a shadow.  When true (the default value), this indicates that the Static Maps service should construct an appropriate
		/// shadow for the image. This shadow is based on the image's visible region and its opacity/transparency. (optional)
		/// </summary>
		[DefaultValue(true)]
		public bool? Shadow { get; set; }

		/// <summary>
		/// Affects the number of pixels marker can use. Markers are limited to sizes of 4096 pixels (64x64 for square images) by default.
		/// This is useful when developing for high-resolution displays, or when generating a map for printing.
		/// The default value is 1. Accepted values are 2 and 4 (4 is only available to Maps API for Business customers.)
		/// See http://stackoverflow.com/questions/10336646/how-can-i-use-high-resolution-custom-markers-with-the-scale-parameter-in-google
		/// </summary>
		/// <remarks>http://code.google.com/apis/maps/documentation/staticmaps/#scale_values</remarks>
		public int? Scale
		{
			get { return _scale; }
			set
			{
				if(value != null)
				{
					Constants.IsExpectedScaleValue(value.Value, true);
				}
				_scale = value;
			}
		}
		private int? _scale;

		public static implicit operator MapMarkers(Location location)
		{
			return new MapMarkers(location);
		}
	}
}
