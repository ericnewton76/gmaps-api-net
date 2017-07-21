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
using System.Threading.Tasks;

using Google.Maps.Internal;

namespace Google.Maps.Direction
{
	public class DirectionService : IDisposable
	{
		public static readonly Uri HttpsUri = new Uri("https://maps.google.com/maps/api/directions/");
		public static readonly Uri HttpUri = new Uri("http://maps.google.com/maps/api/directions/");

		Uri baseUri;
		MapsHttp http;

		public DirectionService(GoogleSigned signingSvc = null, Uri baseUri = null)
		{
			this.baseUri = baseUri ?? HttpsUri;

			this.http = new MapsHttp(signingSvc ?? GoogleSigned.SigningInstance);
		}

		public DirectionResponse GetResponse(DirectionRequest request)
		{
			var url = new Uri(baseUri, request.ToUri());

			return http.Get<DirectionResponse>(url);
		}

		public async Task<DirectionResponse> GetResponseAsync(DirectionRequest request)
		{
			var url = new Uri(baseUri, request.ToUri());

			return await http.GetAsync<DirectionResponse>(url);
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
