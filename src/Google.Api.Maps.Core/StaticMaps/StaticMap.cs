/*
 * 
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Api.Maps.Core.StaticMaps
{
	public class StaticMap
	{
		public static readonly Uri ServiceUri =
			new Uri("http://maps.google.com/maps/api/");

		private static readonly string uriParamsFormat =
			"staticmap?center={0}&zoom={1}&size={2}&format={3}&maptype={4}&mobile={5}&language={6}&markers={7}&path={8}&visible={9}&sensor={10}";

		#region Helper methods

		private static string format(ImageFormat f)
		{
			var result = String.Empty;

			switch (f)
			{
				case ImageFormat.JpgBaseline:
					result = "jpg-baseline";
					break;
				case ImageFormat.Default:
					break;
				default:
					result = f.ToString().ToLowerInvariant();
					break;
			}

			return result;
		}

		private static string mapType(MapType m)
		{
			var result = String.Empty;

			switch (m)
			{
				case MapType.Default:
					break;
				default:
					result = m.ToString().ToLowerInvariant();
					break;
			}

			return result;
		}

		private static string AsQueryString(List<MarkerSet> markerSets)
		{
			List<string> markersList = new List<string>();

			StringBuilder markers = new StringBuilder();
			foreach (var markerSet in markerSets)
			{
				if (!String.IsNullOrEmpty(markerSet.Style.Color))
					markers.Append("color:" + markerSet.Style.Color + "|");
				if (!String.IsNullOrEmpty(markerSet.Style.Icon))
					markers.Append("icon:" + markerSet.Style.Icon + "|");
				if (markerSet.Style.Label != Char.MinValue)
					markers.Append("label:" + markerSet.Style.Label + "|");
				if (markerSet.Style.Size != MarkerSize.Default)
					markers.Append("size:" + markerSet.Style.Size.ToString().ToLowerInvariant() + "|");
				if (markerSet.Style.Shadow != MarkerStyle.DefaultShadow)
					markers.Append("shadow:" + markerSet.Style.Shadow.ToString().ToLowerInvariant() + "|");
				foreach (var marker in markerSet.Markers)
					markers.Append(marker + "|");

				markersList.Add(markers.ToString().TrimEnd('|'));
				markers.Length = 0;
			}

			return String.Join("&markers=", markersList.ToArray());
		}

		private static string AsQueryString(Path path)
		{
			StringBuilder elems = new StringBuilder();
			if (!String.IsNullOrEmpty(path.Style.Color))
				elems.Append("color:" + path.Style.Color + "|");
			if (!String.IsNullOrEmpty(path.Style.FillColor))
				elems.Append("fillcolor:" + path.Style.FillColor + "|");
			if (path.Style.Weight != PathStyle.DefaultWeight)
				elems.Append("weight:" + path.Style.Weight.ToString()+"|");

			if (!String.IsNullOrEmpty(path.EncodedPolyline))
				elems.Append("enc:" + path.EncodedPolyline);

			foreach (var point in path.Points)
			{
				elems.Append(point + "|");
			}

			return elems.ToString().TrimEnd('|');
		}

		#endregion

		public string Center { get; set; }
		public byte Zoom { get; set; }
		public string Size { get; set; }
		public ImageFormat ImageFormat { get; set; }
		public MapType MapType { get; set; }
		public bool Mobile { get; set; }
		public string Language { get; set; }
		public List<MarkerSet> MarkerSets { get; set; }
		public Path Path { get; set; }
		public List<string> ViewportLocations { get; set; }
		public bool Sensor { get; set; }

		public StaticMap()
		{
			MarkerSets = new List<MarkerSet>();
			ViewportLocations = new List<string>();
			Path = new Path();
		}

		public Uri GenerateUri()
		{
			var markers = AsQueryString(MarkerSets);
			var path = AsQueryString(Path);
			var visible = String.Join("|", ViewportLocations.ToArray());

			var uriString = String.Format(uriParamsFormat,
				Center, Zoom, Size, format(ImageFormat), mapType(MapType), Mobile, Language,
				markers, path, visible, Sensor.ToString().ToLowerInvariant());

			return new Uri(ServiceUri, new Uri(uriString, UriKind.Relative));
		}
	}
}
