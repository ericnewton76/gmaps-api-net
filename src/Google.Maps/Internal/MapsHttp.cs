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
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;
using Google.ApiCore;

namespace Google.Maps.Internal
{
	public class MapsHttp : IHttpService, IDisposable
	{
		JsonSerializerSettings settings = new JsonSerializerSettings
		{
			Converters = new List<JsonConverter> {
				new JsonEnumTypeConverter(),
				new JsonLocationConverter()
			}
		};

		ISigningService signingSvc;
		HttpClient client;

		public MapsHttp(ISigningService signingSvc)
		{
			this.signingSvc = signingSvc;
			this.client = new HttpClient();
		}

		public async Task<T> GetAsync<T>(Uri uri) where T : class
		{
			if(this.signingSvc != null)
			{
				uri = signingSvc.GetSignedUri(uri);
			}

			var json = await client.GetStringAsync(uri).ConfigureAwait(false);

			var result = JsonConvert.DeserializeObject<T>(json, settings);

			return result;
		}

		public T Get<T>(Uri uri) where T : class
		{
			return GetAsync<T>(uri).GetAwaiter().GetResult();
		}

		public async Task<Stream> GetStreamAsync(Uri uri)
		{
			if(this.signingSvc != null)
			{
				uri = signingSvc.GetSignedUri(uri);
			}

			return await client.GetStreamAsync(uri).ConfigureAwait(false);
		}

		public Stream GetStream(Uri uri)
		{
			return GetStreamAsync(uri).GetAwaiter().GetResult();
		}

		public void Dispose()
		{
			if (client != null)
			{
				client.Dispose();
				client = null;
			}
		}
	}
}