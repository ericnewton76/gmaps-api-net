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

namespace Google.Maps
{
    interface IGoogleService<TRequest, TResponse>
    {
        Uri BaseUri { get; set; }
        //TResponse GetResponse(TRequest request);
        Task<TResponse> GetResponseAsync(TRequest request);
    }

    /*public abstract class MapsService<TRequest, TResponse> where TResponse : class
    {
        public Uri BaseUri { get; set; }

        public virtual TResponse GetResponse(TRequest request)
        {
            var url = new Uri(this.BaseUri, request.ToUri());
            return Internal.Http.Get(url).As<TResponse>();
        }

        public virtual async Task<TResponse> GetResponseAsync(TRequest request)
        {
            var url = new Uri(this.BaseUri, request.ToUri());
            return await Internal.Http.Get(url).AsAsync<TResponse>();
        }
    }*/
}
