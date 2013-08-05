using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps.Cache
{
    /// <summary>
    /// Provides a generic Uri-request response cache
    /// </summary>
    public interface IUriResponseCache
    {
        /// <summary>
        /// Cache lookup for the given Uri, if avaiable, returns the cached response
        /// </summary>
        /// <param name="request">The request Uri</param>
        /// <param name="cacheLifetime">The maximum age of a cached item. 
        /// (If the cached item is older, null is returned)</param>
        /// <returns>Returns the cached data or null when no cached item is avaiable</returns>
        string GetContent(Uri request, TimeSpan cacheLifetime);

        /// <summary>
        /// Store the given Uri / response in the cache
        /// </summary>
        /// <param name="request"></param>
        /// <param name="responseContent"></param>
        void SaveContent(Uri request, string responseContent);
    }
}
