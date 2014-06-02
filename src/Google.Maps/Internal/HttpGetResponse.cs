using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Google.Maps.Internal
{
    /// <summary>
    /// Represents a http response
    /// </summary>
    public abstract class HttpGetResponse
    {
        /// <summary>
        /// The request uri
        /// </summary>
        public Uri RequestUri { get; protected set; }


        /// <summary>
        /// Determines if a uri response cache shall be used
        /// </summary>
        public bool DontUseCache
        {
            get;
            private set;
        }

        /// <summary>
        /// Was the response data of this response fetched from the cache?
        /// </summary>
        public bool FromCache { get; protected set; }


        /// <summary>
        /// Creates a new HttpResponse with the given uri and the given response cache
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="forceNoCache"></param>
        protected HttpGetResponse(Uri uri, bool forceNoCache)
        {
            RequestUri = uri;
            DontUseCache = forceNoCache;
        }


        /// <summary>
        /// Returns the request uri signed with the default signing instance.
        /// If no signingInstance is avaiable, the original Uri is returned
        /// </summary>
        /// <returns></returns>
        protected Uri GetSignedUri()
        {
            return GetSignedUri(GoogleSigned.SigningInstance);
        }

        /// <summary>
        /// Returns the request uri signed.
        /// If no signingInstance is provided, the original Uri is returned
        /// </summary>
        /// <param name="signingInstance"></param>
        /// <returns></returns>
        protected Uri GetSignedUri(GoogleSigned signingInstance)
        {
            var requestUri = RequestUri;
            if (signingInstance != null)
            {
                requestUri = new Uri(signingInstance.GetSignedUri(RequestUri));
            }
            return requestUri;
        }


        /// <summary>
        /// Returns the response data as string
        /// </summary>
        /// <returns></returns>
        public abstract string AsString();

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
}
