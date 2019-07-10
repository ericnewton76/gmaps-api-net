using System;
using System.Threading.Tasks;

namespace Google.Maps.Geocoding
{
	public interface IGeocodingService : IDisposable
	{
		/// <summary>
		/// Sends the specified request to the Google Maps Geocoding web
		/// service and parses the response as an GeocodingResponse
		/// object.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		GeocodeResponse GetResponse(GeocodingRequest request);

		Task<GeocodeResponse> GetResponseAsync(GeocodingRequest request);
	}
}