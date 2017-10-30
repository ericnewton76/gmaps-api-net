using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.ApiCore;

namespace Google.Maps
{

	/// <summary>
	/// Easy to use facade for all the services
	/// </summary>
    public class Services
    {
		public Services(string apiKey)
		{
			this._SigningService = new GoogleApiSigningService(new GoogleSigned(apiKey));
			this._HttpService = new Google.Maps.Internal.MapsHttp(this._SigningService);
		}

		public Services WithSigningService(ISigningService signingService)
		{
			this._SigningService = signingService;
			return this;
		}
		public Services WithHttpService(IHttpService httpService)
		{
			this._HttpService = httpService;
			return this;
		}

		private GoogleSigned _signingInstance;
		private ISigningService _SigningService;
		private IHttpService _HttpService;

		public ISigningService SigningService { get { return this._SigningService; } }
		public IHttpService HttpService { get { return this._HttpService; } }

	}
}
