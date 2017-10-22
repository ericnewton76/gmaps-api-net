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
using System.Linq;
using System.Collections.Generic;

using Google.Maps.Internal;
using System.ComponentModel;

namespace Google.Maps.StreetView
{
	/// <summary>
	/// The Google Static Maps API returns an image (either GIF, PNG or JPEG)
	/// in response to a HTTP request via a URL. For each request, you can
	/// specify the location of the map, the size of the image, the zoom level,
	/// the type of map, and the placement of optional markers at locations on
	/// the map.
	/// </summary>
	public class StreetViewRequest : BaseRequest
	{
		public StreetViewRequest()
		{
			this.Size = new MapSize(512, 512); //default size is 512x512
		}

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


		/// <summary>
		/// Size specifies the output size of the image in pixels.
		/// For example Size = new MapSize(600,400) returns an image 600 pixels wide, and 400 high.
		/// </summary>
		public MapSize Size
		{
			get { return _size; }
			set
			{
				if(value.Width < Constants.SIZE_WIDTH_MIN) throw new ArgumentOutOfRangeException(string.Format("value.Width cannot be less than {0}.", Constants.SIZE_WIDTH_MIN));
				if(value.Height < Constants.SIZE_HEIGHT_MIN) throw new ArgumentOutOfRangeException(string.Format("value.Height cannot be less than {0}.", Constants.SIZE_HEIGHT_MIN));
				if(value.Width > Constants.SIZE_WIDTH_MAX) throw new ArgumentOutOfRangeException(string.Format("value.Width cannot be greater than {0}.", Constants.SIZE_WIDTH_MAX));
				if(value.Height > Constants.SIZE_HEIGHT_MAX) throw new ArgumentOutOfRangeException(string.Format("value.Height cannot be greater than {0}.", Constants.SIZE_HEIGHT_MAX));
				this._size = value;
			}
		}
		private MapSize _size;

		/// <summary>
		/// Defines the format of the resulting image. By default, the Static
		/// Maps API creates PNG images. There are several possible formats
		/// including GIF, JPEG and PNG types. Which format you use depends on
		/// how you intend to present the image. JPEG typically provides
		/// greater compression, while GIF and PNG provide greater detail. (optional)
		/// </summary>
		/// <remarks>http://code.google.com/apis/maps/documentation/staticmaps/#ImageFormats</remarks>
		public GMapsImageFormats Format { get; set; }

		/// <summary>
		/// Heading indicates the compass heading of the camera. Accepted values are from 0 to 360
		/// (both values indicating North, with 90 indicating East, and 180 South).
		/// If no heading is specified, a value will be calculated that directs the camera towards the specified location,
		/// from the point at which the closest photograph was taken.
		/// </summary>
		public short? Heading
		{
			get
			{
				return _heading;
			}
			set
			{
				if(value != null)
				{
					short headingValue = value.Value;
					Constants.CheckHeadingRange(value.Value, "value");
				}
				_heading = value;
			}
		}
		private short? _heading;

		/// <summary>
		/// pitch (default is 0) specifies the up or down angle of the camera relative to the Street View vehicle.
		/// This is often, but not always, flat horizontal.
		/// Positive values angle the camera up (with 90 degrees indicating straight up);
		/// negative values angle the camera down (with -90 indicating straight down).
		/// </summary>
		[DefaultValue(0)]
		public short Pitch
		{
			get { return _pitch; }
			set
			{
				Constants.CheckPitchRange(value, "value");
				_pitch = value;
			}
		}
		private short _pitch;


		/// <summary>
		/// Builds the request uri parameters
		/// </summary>
		/// <returns></returns>
		public override Uri ToUri()
		{
			QueryStringBuilder qs = new QueryStringBuilder();

			//string zoomStr = null;
			//if(this.Zoom != null)
			//	zoomStr = this.Zoom.ToString();

			//if(this.Center != null) {
			//	string centerStr = this.Center.GetAsUrlParameter();
			//	qs.Append("center", centerStr);
			//}

			if(this.Location != null)
			{
				qs.Append("location", this.Location.GetAsUrlParameter());
			}
			else if(string.IsNullOrEmpty(this.PanoramaId) == false)
			{
				qs.Append("pano", this.PanoramaId);
			}
			else
			{
				throw new InvalidOperationException("Either Location or PanoramaId property are required.");
			}

			WriteBitmapOutputParameters(qs);

			var InvariantCulture = System.Globalization.CultureInfo.InvariantCulture;

			if(this.Pitch != 0)
			{
				qs.Append("pitch", Pitch.ToString(InvariantCulture));
			}

			if(this.Heading != null && this.Heading.GetValueOrDefault(0) != 0)
			{
				qs.Append("heading", Heading.Value.ToString(InvariantCulture));
			}


			var url = "streetview?" + qs.ToString();

			return new Uri(StreetViewService.HttpsUri, new Uri(url, UriKind.Relative));
		}

		private void WriteBitmapOutputParameters(QueryStringBuilder qs)
		{
			string formatStr = null;
			switch(this.Format)
			{
				case GMapsImageFormats.Unspecified: break;
				case GMapsImageFormats.JPGbaseline: formatStr = "jpg-baseline"; break;
				default: formatStr = this.Format.ToString().ToLower(); break;
			}

			qs.Append("format", formatStr);

			qs.Append("size", string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}x{1}", Size.Width, Size.Height));

			//qs.Append("scale", Scale == null ? (string)null : Scale.Value.ToString())
		}

	}
}
