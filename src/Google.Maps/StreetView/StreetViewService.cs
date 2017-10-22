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
using System.IO;
using System.Threading.Tasks;

using Google.Maps.Internal;

namespace Google.Maps.StreetView
{
	/// <summary>
	/// The Google Street View Image API lets you embed a static (non-interactive) Street View panorama or thumbnail
	/// into your web page, without the use of JavaScript. The viewport is defined with URL parameters sent through
	/// a standard HTTP request, and is returned as a static image.
	/// </summary>
	/// <see href="https://developers.google.com/maps/documentation/streetview/intro"/>
	public class StreetViewService : IDisposable
	{
		public static readonly Uri HttpsUri = new Uri("https://maps.googleapis.com/maps/api/streetview");

		Uri baseUri;
		MapsHttp http;

		public StreetViewService(GoogleSigned signingSvc = null, Uri baseUri = null)
		{
			this.baseUri = baseUri ?? HttpsUri;

			this.http = new MapsHttp(signingSvc ?? GoogleSigned.SigningInstance);
		}

		public byte[] GetImage(StreetViewRequest request)
		{
			var stream = GetStream(request);

			return StreamToArray(stream);
		}

		public async Task<byte[]> GetImageAsync(StreetViewRequest request)
		{
			var stream = await GetStreamAsync(request);

			return StreamToArray(stream);
		}

		public Stream GetStream(StreetViewRequest request)
		{
			var uri = new Uri(baseUri, request.ToUri());

			return http.GetStream(uri);
		}

		public Task<Stream> GetStreamAsync(StreetViewRequest request)
		{
			var uri = new Uri(baseUri, request.ToUri());

			return http.GetStreamAsync(uri);
		}

		Byte[] StreamToArray(Stream inputStream)
		{
			var outputStream = new MemoryStream();

			int bytesRead = 0;
			const int BYTE_BUFFER_LENGTH = 4096;
			byte[] buffer = new byte[BYTE_BUFFER_LENGTH];

			do
			{
				bytesRead = inputStream.Read(buffer, 0, BYTE_BUFFER_LENGTH);
				outputStream.Write(buffer, 0, bytesRead);
			}
			while (bytesRead > 0);

			return outputStream.ToArray();
		}

		public void Dispose()
		{
			if (http != null)
			{
				http.Dispose();
				http = null;
			}
		}
	}
}
