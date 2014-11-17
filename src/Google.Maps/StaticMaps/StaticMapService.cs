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
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Google.Maps.StaticMaps
{
	/// <summary>
	/// The Google Static Maps API lets you embed a Google Maps image on your web page without requiring JavaScript or any dynamic page 
	/// loading. The Google Static Map service creates your map based on URL parameters sent through a standard HTTP request and returns the 
	/// map as an image you can display on your web page.
	/// </summary>
	/// <see cref="https://developers.google.com/maps/documentation/staticmaps/"/>
	public class StaticMapService
	{
		#region Http/Https Uris and Constructors

		public static readonly Uri HttpsUri = new Uri("https://maps.google.com/maps/api");
		public static readonly Uri HttpUri = new Uri("http://maps.google.com/maps/api");

		public Uri BaseUri { get; set; }

		public StaticMapService() : this(HttpUri)
		{
		}
		public StaticMapService(Uri baseUri)
		{
			this.BaseUri = baseUri;
		}
		#endregion

		/// <summary>
		/// Retrieves a map and returns back the image bytes
		/// </summary>
		/// <param name="request"></param>
		/// <returns>byte array of the image bytes</returns>
		public byte[] GetImageBytes(StaticMapRequest mapOptions)
		{
			MemoryStream outputStream = new MemoryStream();

			GetMapToStream(mapOptions, outputStream);

			return outputStream.ToArray();
		}

		/// <summary>
		/// Retrieves the map with the given request and writes the image bytes to the given target stream.
		/// </summary>
		/// <param name="request"></param>
		/// <param name="targetStream"></param>
		/// <returns>number of bytes written to the target stream</returns>
		public int GetMapToStream(StaticMapRequest mapOptions, System.IO.Stream outputStream)
		{
			Uri requestUri = new Uri(BaseUri, mapOptions.ToUri());
			GoogleSigned signingInstance = GoogleSigned.SigningInstance;
			if (signingInstance != null)
			{
				requestUri = new Uri(signingInstance.GetSignedUri(requestUri));
			}

			int totalBytes = 0;

			WebRequest request = WebRequest.Create(requestUri);

			using (WebResponse response = request.GetResponse())
			{
				Stream inputStream = response.GetResponseStream();

				int bytesRead = 0; 
				const int BYTE_BUFFER_LENGTH = 4096;
				byte[] buffer = new byte[BYTE_BUFFER_LENGTH];

				do
				{
					bytesRead = inputStream.Read(buffer, 0, BYTE_BUFFER_LENGTH);
					outputStream.Write(buffer, 0, bytesRead);
					totalBytes += bytesRead;
				}
				while (bytesRead > 0);
			}

			return totalBytes;
		}

		/// <summary>
		/// Retrieves a static map image at a default size of 512x512 with the given parameters.
		/// </summary>
		/// <param name="center"></param>
		/// <param name="zoom"></param>
		/// <param name="sensor"></param>
		/// <returns></returns>
		public byte[] GetMap(Location center, int zoom, bool sensor)
		{
			StaticMapRequest request = new StaticMapRequest()
			{
				Center = center,
				Zoom = zoom,
				Sensor = sensor
			};

			return GetImageBytes(request);
		}

		/// <summary>
		/// Retrieves a static map image at a default size of 512x512 and using the specified image format.
		/// </summary>
		/// <param name="center">A location to center the map on</param>
		/// <param name="zoom">Zoom level to use</param>
		/// <param name="sensor">Pass true if the location was provided via a sensor</param>
		/// <param name="imageFormat">The format of the image</param>
		/// <returns></returns>
		public byte[] GetMap(Location center, int zoom, GMapsImageFormats imageFormat, bool sensor)
		{
			StaticMapRequest request = new StaticMapRequest()
			{
				Format = imageFormat,
				Center = center,
				Zoom = zoom,
				Sensor = sensor
			};

			return GetImageBytes(request);
		}

		/// <summary>
		/// Retrieves a static map image at a default size of 512x512 and using the specified image format.
		/// </summary>
		/// <param name="center">A location to center the map on</param>
		/// <param name="zoom">Zoom level to use</param>
		/// <param name="sensor">Pass true if the location was provided via a sensor</param>
		/// <param name="imageFormat">The format of the image</param>
		/// <returns></returns>
		public byte[] GetMap(Location center, int zoom, System.Drawing.Size size, GMapsImageFormats imageFormat, bool sensor)
		{
			StaticMapRequest request = new StaticMapRequest()
			{
				Format = imageFormat,
				Size = size,
				Center = center,
				Zoom = zoom,
				Sensor = sensor
			};

			return GetImageBytes(request);
		}


		public byte[] GetMapWithCenterMarked(Location center, int zoom, bool sensor)
		{
			StaticMapRequest request = new StaticMapRequest()
			{
				Center = center,
				Zoom = zoom,
				Sensor = sensor
			};
			request.Markers.Add(request.Center);

			return GetImageBytes(request);
		}


	}
}
