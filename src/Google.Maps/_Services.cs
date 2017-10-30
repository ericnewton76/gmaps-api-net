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
		public Services(string apiKey) : this(new GoogleSigned(apiKey))
		{
		}

		public Services(GoogleSigned signingInstance) 
		{
			this._SigningService = new GoogleApiSigningService(signingInstance);
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


		public Direction.DirectionService DirectionService
		{
			get { return new Direction.DirectionService(HttpService, null); }
		}
		public Geocoding.GeocodingService GeocodingService
		{
			get { return new Geocoding.GeocodingService(HttpService, null); }
		}
		public StaticMaps.StaticMapService StaticMapsService
		{
			get { return new StaticMaps.StaticMapService(HttpService, null); }
		}


	}
}
