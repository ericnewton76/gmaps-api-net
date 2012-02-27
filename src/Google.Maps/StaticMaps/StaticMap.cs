/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Google.Api.Maps.Service.StaticMaps
{
	/// <summary>
	/// The Google Static Maps API returns an image (either GIF, PNG or JPEG)
	/// in response to a HTTP request via a URL. For each request, you can
	/// specify the location of the map, the size of the image, the zoom level,
	/// the type of map, and the placement of optional markers at locations on
	/// the map.
	/// </summary>
	public class StaticMap
	{
		public static readonly Uri BaseUri =
			new Uri("http://maps.google.com/maps/api/");

		/// <summary>
		/// Defines the center of the map, equidistant from all edges of the
		/// map. This parameter takes a location as either a comma-separated
		/// {latitude,longitude} pair (e.g. "40.714728,-73.998672") or a
		/// string address (e.g. "city hall, new york, ny") identifying a
		/// unique location on the face of the earth.
		/// </summary>
		/// <remarks>Required if markers not present.</remarks>
		/// <see cref="http://code.google.com/apis/maps/documentation/staticmaps/#Locations"/>
		public string Center { get; set; }

		/// <summary>
		/// Defines the zoom level of the map, which determines the
		/// magnification level of the map. This parameter takes a numerical
		/// value corresponding to the zoom level of the region desired.
		/// </summary>
		/// <remarks>Required if markers not present.</remarks>
		/// <see cref="http://code.google.com/apis/maps/documentation/staticmaps/#Zoomlevels"/>
		public string Zoom { get; set; }

		/// <summary>
		/// Defines the rectangular dimensions of the map image. This parameter
		/// takes a string of the form valuexvalue where horizontal pixels are
		/// denoted first while vertical pixels are denoted second. For example,
		/// 500x400 defines a map 500 pixels wide by 400 pixels high. If you
		/// create a static map that is 100 pixels wide or smaller, the
		/// "Powered by Google" logo is automatically reduced in size.
		/// </summary>
		/// <remarks>Required.</remarks>
		public string Size { get; set; }

		/// <summary>
		/// Defines the format of the resulting image. By default, the Static
		/// Maps API creates PNG images. There are several possible formats
		/// including GIF, JPEG and PNG types. Which format you use depends on
		/// how you intend to present the image. JPEG typically provides
		/// greater compression, while GIF and PNG provide greater detail.
		/// </summary>
		/// <remarks>Optional.</remarks>
		/// <see cref="http://code.google.com/apis/maps/documentation/staticmaps/#ImageFormats"/>
		public string Format { get; set; }

		/// <summary>
		/// Defines the type of map to construct. There are several possible
		/// maptype values, including roadmap, satellite, hybrid, and terrain.
		/// </summary>
		/// <remarks>Optional.</remarks>
		/// <see cref="http://code.google.com/apis/maps/documentation/staticmaps/#MapTypes"/>
		public string MapType { get; set; }

		/// <summary>
		/// Specifies whether the map will be displayed on a mobile device. Valid
		/// values are true or false. Maps displayed on mobile devices may use
		/// different tilesets optimized for those devices.
		/// </summary>
		/// <remarks>Optional.</remarks>
		/// <see cref="http://code.google.com/apis/maps/documentation/staticmaps/#Mobile"/>
		public string Mobile { get; set; }

		/// <summary>
		/// Defines the language to use for display of labels on map tiles. Note
		/// that this parameter is only supported for some country tiles; if the
		/// specific language requested is not supported for the tile set, then
		/// the default language for that tileset will be used.
		/// </summary>
		/// <remarks>Optional.</remarks>
		public string Language { get; set; }

		/// <summary>
		/// Define one or more markers to attach to the image at specified
		/// locations. This parameter takes a single marker definition with
		/// parameters separated by the pipe character (|). Multiple markers
		/// may be placed within the same markers parameter as long as they
		/// exhibit the same style; you may add additional markers of
		/// differing styles by adding additional markers parameters. Note that
		/// if you supply markers for a map, you do not need to specify the
		/// (normally required) center and zoom parameters.
		/// </summary>
		/// <remarks>Optional.</remarks>
		/// <see cref="http://code.google.com/apis/maps/documentation/staticmaps/#Markers"/>
		public string Markers { get; set; }

		/// <summary>
		/// Defines a single path of two or more connected points to overlay on
		/// the image at specified locations. This parameter takes a string of
		/// point definitions separated by the pipe character (|). You may
		/// supply additional paths by adding additional path parameters. Note
		/// that if you supply a path for a map, you do not need to specify the
		/// (normally required) center and zoom parameters.
		/// </summary>
		/// <remarks>Optional.</remarks>
		/// <see cref="http://code.google.com/apis/maps/documentation/staticmaps/#Paths"/>
		public string Path { get; set; }

		/// <summary>
		/// Specifies one or more locations that should remain visible on the
		/// map, though no markers or other indicators will be displayed. Use
		/// this parameter to ensure that certain features or map locations
		/// are shown on the static map.
		/// </summary>
		/// <remarks>Optional.</remarks>
		public string Visible { get; set; }

		/// <summary>
		/// Specifies whether the application requesting the static map is
		/// using a sensor to determine the user's location. This parameter
		/// is required for all static map requests.
		/// </summary>
		/// <remarks>Required.</remarks>
		/// <see cref="http://code.google.com/apis/maps/documentation/staticmaps/#Sensor"/>
		public string Sensor { get; set; }

		public Uri ToUri()
		{
			var url = "staticmap?"
				.Append("center=", Center)
				.Append("zoom=", Zoom)
				.Append("size=", Size)
				.Append("format=", Format)
				.Append("maptype=", MapType)
				.Append("mobile=", Mobile)
				.Append("language=", Language)
				.Append("markers=", Markers)
				.Append("path=", Path)
				.Append("visible=", Visible)
				.Append("sensor=", Sensor)
				.TrimEnd('&');

			return new Uri(BaseUri, new Uri(url, UriKind.Relative));
		}
	}
}
