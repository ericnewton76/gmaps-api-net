using System;
using System.Threading.Tasks;

using Google.Maps.Internal;
using Google.Maps.ApiCore;

namespace Google.Maps.Roads
{

	public class RoadsService : BaseGmapsServiceTypedResponse<SnapToRoadsRequest, SnapToRoadsResponse>
	{
		public static readonly Uri HttpsUri = new Uri("https://roads.googleapis.com/v1/");

		public RoadsService(IHttpService httpService, Uri baseUri)
		{
			this.HttpService = httpService;
			this.BaseUri = (baseUri != null ? baseUri : HttpsUri);
		}

	}

}