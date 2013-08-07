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
using System.Net;
using System.Text;
using Google.Maps.Cache;
using Newtonsoft.Json;

namespace Google.Maps.Internal
{
	/// <summary>
	/// Provides an intuitive and simple HTTP client wrapper.
	/// </summary>
	public static class Http
	{
	    /// <summary>
	    /// How old can a cached response be at max?
	    /// </summary>
	    public static TimeSpan DefaultCacheLifeTime = TimeSpan.FromDays(1);


        /// <summary>
        /// Represents a http response
        /// </summary>
		public class HttpGetResponse
        {

            private readonly IUriResponseCache _uriResponseCache;

            /// <summary>
            /// The request uri
            /// </summary>
			protected Uri RequestUri { get; set; }

            /// <summary>
            /// Is a cache provider avaiable?
            /// </summary>
            public bool IsCacheAvaiable
            {
                get { return _uriResponseCache != null; }
            }

            /// <summary>
            /// Determines if the local uri response cache shall be used
            /// </summary>
            public bool DontUseCache
            {
                get;
                private set;
            }

            /// <summary>
            /// Was the data of this response fetched from the cache?
            /// </summary>
            public bool FromCache { get; private set; }


            /// <summary>
            /// Creates a new HttpResponse with the given uri
            /// </summary>
            /// <param name="uri"></param>
            public HttpGetResponse(Uri uri)
                :this(uri, null, false)
            {
            }

            /// <summary>
            /// Creates a new HttpResponse with the given uri and the given response cache
            /// </summary>
            /// <param name="uri"></param>
            /// <param name="uriResponseCache"></param>
            public HttpGetResponse(Uri uri, IUriResponseCache uriResponseCache, bool forceNoCache)
			{
				RequestUri = uri;
                DontUseCache = forceNoCache;
                _uriResponseCache = uriResponseCache;
			}

			protected virtual StreamReader GetStreamReader(Uri uri)
			{
				return GetStreamReader(uri, GoogleSigned.SigningInstance);
			}


            protected virtual StreamReader GetStreamReader(Uri uri, GoogleSigned signingInstance)
            {
                StreamReader sr = null;

                var requestUri = uri;
                if (signingInstance != null)
                {
                    requestUri = new Uri(signingInstance.GetSignedUri(uri));
                }

                var response = WebRequest.Create(requestUri).GetResponse();
                var rs = response.GetResponseStream();
                if (rs != null)
                    sr = new StreamReader(rs);

                return sr;
            }

            /// <summary>
            /// Returns the cached response for the given Uri if avaiable
            /// </summary>
            /// <param name="uri"></param>
            /// <param name="cacheLifetime"></param>
            /// <returns></returns>
            private string GetCachedResponse(Uri uri, TimeSpan cacheLifetime)
            {
                string cachedData = null;
                if(_uriResponseCache != null)
                {
                    cachedData = _uriResponseCache.GetContent(uri, cacheLifetime);
                }
                return cachedData;
            }


            private void SaveToCache(Uri uri, string data)
            {
                if (_uriResponseCache != null)
                {
                    _uriResponseCache.SaveContent(uri, data);
                }
            }



            /// <summary>
            /// Returns the response data as string
            /// </summary>
            /// <returns></returns>
			public virtual string AsString()
			{
				var output = String.Empty;

                if (!DontUseCache && IsCacheAvaiable)
                    output = GetCachedResponse(RequestUri, DefaultCacheLifeTime);

                FromCache = !String.IsNullOrEmpty(output);

                if (!FromCache)
                {
                    using (var reader = GetStreamReader(this.RequestUri))
                    {
                        output = reader.ReadToEnd();
                        SaveToCache(RequestUri, output);
                    }
                }

                return output;
			}

			/// <summary>
			/// Parses the response into its JSON object representation
			/// </summary>
			/// <typeparam name="T"></typeparam>
			/// <returns></returns>
            public virtual T As<T>() where T : class
			{
			    T output = null;

			    var responseData = AsString();

                using (var sr = new StringReader(responseData))
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    serializer.Converters.Add(new JsonEnumTypeConverter());
                    serializer.Converters.Add(new JsonLocationConverter());

                    output = serializer.Deserialize<T>(jsonReader);
                }

			    return output;
			}
        }

		/// <summary>
		/// Get the 
		/// </summary>
		/// <param name="uri"></param>
		/// <returns></returns>
		public static HttpGetResponse Get(Uri uri, bool forceNoCache = false)
		{
            return Factory.CreateResponse(uri, forceNoCache);
		}

		/// <summary>
		/// Gets or sets the factory that provides HttpGetResponse instances. Crude depency injection for the time being.
		/// </summary>
		public static HttpGetResponseFactory Factory = new HttpGetResponseFactory();


		/// <summary>
		/// A factory class for building HttpGetResponse instances.
		/// </summary>
		public class HttpGetResponseFactory
		{
            /// <summary>
            /// Gets/Sets the UriResponse cache
            /// </summary>
		    public IUriResponseCache UriResponseCache { get; set; }
		

			/// <summary>
			/// Builds a standard HttpGetResponse instance.
			/// </summary>
			/// <param name="uri"></param>
			/// <returns></returns>
            public virtual HttpGetResponse CreateResponse(Uri uri, bool forceNoCache = false)
			{
                return new HttpGetResponse(uri, UriResponseCache, forceNoCache);
			}
		}

	}
}
