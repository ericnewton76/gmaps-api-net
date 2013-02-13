using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace Google.Maps.Test.Integrations
{
	public class HttpGetResponseFromResource : Google.Maps.Internal.Http.HttpGetResponse
	{
		System.Reflection.Assembly S_testAssembly = Assembly.GetAssembly(typeof(HttpGetResponseFromResource));

		public HttpGetResponseFromResource(Uri uri) : base(uri)
		{
		}

		private string _resourcePath;
		public string ResourcePath { get { return this._resourcePath; } }

		protected override System.IO.StreamReader GetStreamReader(Uri uri)
		{
			System.Text.StringBuilder queryString = new StringBuilder(uri.Query);
			queryString.Remove(0, 1); //remove the initial "?"
			queryString.Replace("&sensor=false",""); //clear off sensor=false
			queryString.Replace("&sensor=true", ""); // clear off sensor=true

			this._resourcePath = "Google.Maps.Test.Integrations.json_queries." + queryString.ToString() + ".json";

			Stream resourceStream = S_testAssembly.GetManifestResourceStream(this._resourcePath);
			return new StreamReader(resourceStream);
		}
	}

	public class HttpGetResponseFromResourceFactory : Google.Maps.Internal.Http.HttpGetResponseFactory
	{
		public override Internal.Http.HttpGetResponse CreateResponse(Uri uri)
		{
			return new HttpGetResponseFromResource(uri);
		}
	}
}
