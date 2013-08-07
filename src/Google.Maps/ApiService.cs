using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps
{
    public abstract class ApiService
    {
        public Uri BaseUri { get; set; }


        protected Google.Maps.Internal.Http.HttpGetResponse GetHttpResponse(ApiRequest request, bool forceNoCache = false)
        {
            var url = new Uri(this.BaseUri, request.ToUri());
            return Internal.Http.Get(url, forceNoCache);
        }
    }
}
