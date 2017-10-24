using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;

using FluentAssertions;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Google.Maps.Direction
{
	[TestFixture]
	public class Directions_Json_Validators
	{
		GoogleSigned TestingApiKey;
		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			TestingApiKey = SigningHelper.GetApiKey();
		}

		[Test]
		[TestCase("/maps/api/directions/json?origin=oxford+street+london+UK&destination=bond+street+london+UK&mode=transit")]
		[TestCase("/maps/api/directions/json?origin=32801&destination=32803&mode=transit")]
		public async Task TestMethod(string relativeUri)
		{
			Uri uri = new Uri(new Uri("https://maps.google.com/"), relativeUri);

			var task1 = GetJObjectAsync(uri);
			var task2 = Task.Run(() => GetTypedResponseAsync(uri, "direction")).ConfigureAwait(false);

			var snapshotJObject = await task2;
			var serviceJObject = await task1;

			serviceJObject.ShouldBeEquivalentTo(snapshotJObject);
			
		}

		private async Task<JObject> GetJObjectAsync(Uri uri)
		{
			System.Net.Http.HttpClient httpclient = new System.Net.Http.HttpClient();

			var signeduri = TestingApiKey.GetSignedUri(uri);
			var responseBody = await httpclient.GetStringAsync(signeduri).ConfigureAwait(false);

			return JObject.Parse(responseBody);
		}

		private JObject GetTypedResponseAsync(Uri uri, string apiName)
		{
			//string parameters = uri.Query.Replace("&", "`a`").Replace("%", "`p`");

			string baseName = "Google.Maps.Test.Direction";
			string uriHash = Test.Helpers.GetSHA1HashString(uri.Query).Substring(0, 8);

			string resourceName = baseName + "." + apiName + "." + uriHash + ".json";

			var assembly = typeof(Test.Helpers).GetTypeInfo().Assembly;

			using(var stream = assembly.GetManifestResourceStream(resourceName))
			{
				if(stream == null) throw new Exception(string.Format("failed to find '{0}.{1}.json'.", apiName, uriHash));

				using(StreamReader sr = new StreamReader(stream))
				{
					using(JsonReader reader = new JsonTextReader(sr))
					{
						JObject jobject = JObject.Load(reader);
						return jobject;
					}
				}
			}
			
		}




	}
}
