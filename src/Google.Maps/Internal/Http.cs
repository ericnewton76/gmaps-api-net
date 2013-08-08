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
	    /// Get the 
	    /// </summary>
	    /// <param name="uri"></param>
	    /// <param name="forceNoCache"></param>
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
		    /// Builds a standard HttpGetResponse instance.
		    /// </summary>
		    /// <param name="uri"></param>
		    /// <param name="forceNoCache"></param>
		    /// <returns></returns>
		    public virtual HttpGetResponse CreateResponse(Uri uri, bool forceNoCache = false)
			{
                return new CachedHttpGetResponse(uri, forceNoCache);
			}
		}

	}
}
