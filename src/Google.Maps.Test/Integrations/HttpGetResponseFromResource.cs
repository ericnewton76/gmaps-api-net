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
		public string BaseResourcePath { get { return this._resourcePath; } set { this._resourcePath = value; } }

		protected override System.IO.StreamReader GetStreamReader(Uri uri)
		{
			string outputType = uri.Segments[uri.Segments.Length - 1];

			System.Text.StringBuilder queryString = new StringBuilder(uri.OriginalString.Substring(uri.OriginalString.IndexOf("?")+1));
			queryString.Replace("&sensor=false",""); //clear off sensor=false
			queryString.Replace("&sensor=true", ""); // clear off sensor=true

			//have to replace any remaining ampersands with $ due to filename limitations.
			queryString.Replace("&", "$").Replace("|","!").Replace("%","~");

			string resourcePath = this.BaseResourcePath + string.Format(".{0}_queries.{1}.{0}", outputType, queryString.ToString());

			Stream resourceStream = S_testAssembly.GetManifestResourceStream(resourcePath);

			if (resourceStream == null)
			{
				string message = string.Format(
@"Failed to find resource for query '{0}'.
BaseResourcePath: '{2}'
Resource path used: '{1}'
Ensure a file exists at that resource path and the file has its Build Action set to ""Embedded Resource"".", queryString.ToString(), resourcePath, BaseResourcePath);
				throw new FileNotFoundException(message);
			}

			return new StreamReader(resourceStream);
		}
	}

	public class HttpGetResponseFromResourceFactory : Google.Maps.Internal.Http.HttpGetResponseFactory
	{
		public HttpGetResponseFromResourceFactory(string baseResourcePath)
		{
			this.BaseResourcePath = baseResourcePath;
		}

		public string BaseResourcePath { get; set; }

		public override Internal.Http.HttpGetResponse CreateResponse(Uri uri)
		{
			return new HttpGetResponseFromResource(uri) { BaseResourcePath = this.BaseResourcePath };
		}
	}
}
