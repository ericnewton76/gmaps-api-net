using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Maps
{
	public static class SigningHelper
	{
		static SigningHelper()
		{
			//during testing, get api key from the GOOGLE_API_KEY environment variable, to enable more flexibility and try to prevent OverQuotaLimit 
			S_ApiKey = Environment.GetEnvironmentVariable("GOOGLE_API_KEY");

			//Log.Info("GetEnvironmentVariable(\"GOOGLE_API_KEY\")='{0}'.",S_ApiKey);

			//for local testing, you can either use the Debugger to modify the S_ApiKey static variable
			//or set the Debugging Environment variable via the Visual Stdio Debugging properties dialog. 
			//for more info, see https://stackoverflow.com/a/155363/323456

			//for nunit test, might need to use the NUnit Test Settings file

			//if env["GOOGLE_API_KEY"] is empty, use a default key
			if(string.IsNullOrEmpty(S_ApiKey))
			{
				//Log.Info("Setting ApiKey to a default key.");

				//this api key can be used for individual developer machines
				//you may get OverQueryLimit responses though
				S_ApiKey = "AIzaSyDV-0ftj1tsjfd6GnEbtbxwHXnv6iR3UEU";
			}

			//Note: don't specifically say code or api key or something here.  The key should be IP restricted but lets keep it obscure.
			Console.WriteLine("SigningHelper: Initialized using '{0}' for testing.", S_ApiKey);
		}

		/// <summary>Holds the ApiKey used for testing</summary>
		private static string S_ApiKey;

		public static GoogleSigned GetPrivateKey()
		{
			throw new NotImplementedException();
		}

		public static GoogleSigned GetApiKey()
		{
			return new GoogleSigned(S_ApiKey);
		}
	}
}
