using Google.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.ApiCore
{
	public class GoogleApiSigningService : ISigningService
	{
		public GoogleApiSigningService(Google.Maps.GoogleSigned signingInstance)
		{
			if(signingInstance == null) throw new ArgumentNullException("signingInstance");
			this._SigningInstance = signingInstance;
		}

		private GoogleSigned _SigningInstance;

		public Uri GetSignedUri(Uri value)
		{
			return new Uri(_SigningInstance.GetSignedUri(value));
		}
	}
}
