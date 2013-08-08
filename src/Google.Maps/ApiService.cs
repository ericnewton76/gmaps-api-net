using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps
{
    /// <summary>
    /// Represents the base class for all google api services
    /// </summary>
    public abstract class ApiService
    {
        /// <summary>
        /// The base Uri for this service
        /// </summary>
        public Uri BaseUri { get; set; }


        /// <summary>
        /// Gets a Http-Get-Response from the given ApiRequest
        /// </summary>
        /// <param name="request"></param>
        /// <param name="forceNoCache">If set to true, no cached data will be used.</param>
        /// <returns></returns>
        protected Internal.Http.HttpGetResponse GetHttpResponse(ApiRequest request, bool forceNoCache = false)
        {
            var url = new Uri(this.BaseUri, request.ToUri());
            return Internal.Http.Get(url, forceNoCache);
        }
    }
}
