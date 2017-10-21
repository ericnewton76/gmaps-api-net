using System;
using System.Threading.Tasks;

using Google.Maps.Internal;

namespace Google.Maps.Roads
{
	public class RoadsService : IDisposable
	{
		public static readonly Uri HttpsUri = new Uri("https://roads.googleapis.com/v1/");

		Uri baseUri;
		MapsHttp http;

		public RoadsService(GoogleSigned signingSvc = null, Uri baseUri = null)
		{
			this.baseUri = baseUri ?? HttpsUri;

			this.http = new MapsHttp(signingSvc ?? GoogleSigned.SigningInstance);
		}

		public void Dispose()
		{
			if (http != null)
			{
				http.Dispose();
				http = null;
			}
		}

		public SnapToRoadsResponse GetResponse(SnapToRoadsRequest request)
		{
			var url = new Uri(baseUri, request.ToUri());

			return http.Get<SnapToRoadsResponse>(url);
		}

		public async Task<SnapToRoadsResponse> GetResponseAsync(SnapToRoadsRequest request)
		{
			var url = new Uri(baseUri, request.ToUri());

			return await http.GetAsync<SnapToRoadsResponse>(url);
		}
	}
}