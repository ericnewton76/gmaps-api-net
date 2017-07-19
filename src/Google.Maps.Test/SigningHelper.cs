using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Maps
{
	public static class SigningHelper
	{
		public static GoogleSigned GetPrivateKey()
		{
			throw new NotImplementedException();
		}

		public static GoogleSigned GetApiKey()
		{
			return new GoogleSigned("AIzaSyDV-0ftj1tsjfd6GnEbtbxwHXnv6iR3UEU");
		}
	}
}
