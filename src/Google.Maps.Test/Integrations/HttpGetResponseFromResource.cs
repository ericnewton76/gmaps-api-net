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

		private string _resourceName;
		private string _resourcePath;
		public void SetSourceFile(string testFixtureName, string resourceName)
		{
			this._resourceName = resourceName + ".json";
			this._resourcePath = "Google.Maps.Test.Integrations." + testFixtureName + "." + resourceName + ".json";
		}

		protected override System.IO.StreamReader GetStreamReader(Uri uri)
		{
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
