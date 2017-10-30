using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.ApiCore
{
	public class GoogleApiSigningService : ISigningService
	{
		public GoogleApiSigningService(Google.Maps.GoogleSigned signInfo)
		{

		}

		public Uri GetSignedUri(Uri value)
		{
			throw new NotImplementedException();
		}
	}
}
