using System;
using System.Security.Cryptography;
using System.Text;

namespace Google.Maps
{
	/// <summary>
	/// Stores a Google Business API customer's signing information to be passed with service requests to Google's APIs.
	/// </summary>
	/// <remarks>
	/// Use GoogleSigned.AssignAllServices() method to attach the signing information to all outgoing requests, usually during App Startup.
	/// </remarks>
	public class GoogleSigned
	{
		private byte[] _privateKeyBytes;
		private string _idString;
		private string _channelId;
		private string _referralUrl;
		private GoogleSignedType _signType = GoogleSignedType.ApiKey;

		/// <summary>
		/// Used by all the services except Geolocation API and Places API
		/// </summary>
		private static GoogleSigned S_universalSigningInstance;

		public GoogleSigned(string apiKey, string usablePrivateKey, GoogleSignedType signType = GoogleSignedType.ApiKey)
		{
			if(usablePrivateKey != null)
			{
				//might come encoded as Base64 for Urls.
				//Use normal conventions for Convert.FromBase64String
				usablePrivateKey = usablePrivateKey.Replace("-", "+").Replace("_", "/");

				_privateKeyBytes = Convert.FromBase64String(usablePrivateKey);
			}

			_idString = apiKey;
			_signType = signType;
		}

		/// <summary>
		/// Parses the value from the AppSettings[key] and generates the proper GoogleSigned instance from it.
		/// </summary>
		/// <remarks>
		/// apikey=YOUR_KEY[&secret=SHARED_SECRET]
		/// clientId=gme-YOUR_CLIENT_ID&secret=SHARED_SECRET
		/// </remarks>
		/// <param name="appSettings"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static GoogleSigned FromValueString(string value)
		{
			if(value == null)
			{
				value = "";
			}

			string[] check = new string[2] { "", "" };
			var split = value.Split('&');

			if(split.Length > 0)
				check[0] = split[0] ?? "";
			if(split.Length > 1)
				check[1] = split[1] ?? "";

			GoogleSignedType signedType = (GoogleSignedType)0;
			string idString = null;

			if(check[0].StartsWith("apikey", StringComparison.OrdinalIgnoreCase))
			{
				signedType = GoogleSignedType.ApiKey;
				idString = check[0].Substring(7);
			}
			else if(check[0].StartsWith("clientId", StringComparison.OrdinalIgnoreCase))
			{
				signedType = GoogleSignedType.Business;
				idString = check[0].Substring(9);
			}

			string usablePrivateKey = null;

			if(check[1].StartsWith("secret", StringComparison.OrdinalIgnoreCase))
			{
				usablePrivateKey = check[1].Substring(7);
			}

			if(String.IsNullOrEmpty(idString) == false)
			{
				return new GoogleSigned(idString, usablePrivateKey, signedType);
			}

			throw
				new ArgumentException(
					string.Format("Failed to determine Google Signing Info from '{0}'.", value),
					nameof(value)
				);
			
		}

		/// <summary>
		/// Gets or sets the GoogleSigned instance to use for all of the various service calls.
		/// </summary>
		public static GoogleSigned SigningInstance
		{
			get { return S_universalSigningInstance; }
		}


		public string ReferralUrl { get { return _referralUrl; } }


		/// <summary>
		/// Assigns the given SigningInstance to all services that can utilize it.  Note that some of the services do not currently use the signature method.
		/// </summary>
		/// <param name="signingInstance"></param>
		public static void AssignAllServices(GoogleSigned signingInstance)
		{
			S_universalSigningInstance = signingInstance;
		}

		/// <summary>
		/// Appends proper ApiKey or ClientId and possibly the signature for the given Uri.  
		/// </summary>
		/// <remarks>
		/// Please note, If no usablePrivateKey specified in the constructor, then no signature can be generated.
		/// </remarks>
		/// <param name="uri"></param>
		/// <returns></returns>
		public string GetSignedUri(Uri uri)
		{
			var builder = new UriBuilder(uri);

			if(_signType == GoogleSignedType.Business)
			{
				builder.Query = builder.Query.Substring(1) + "&client=" + _idString;
				

				if (!string.IsNullOrEmpty(_channelId))
				{
					builder.Query = builder.Query.Substring(1) + "&channel=" + _channelId;
				}

			}
			else
			{
				builder.Query = builder.Query.Substring(1) + "&key=" + _idString;
			}

			uri = builder.Uri;

			string signatureParam = "";
			if(_privateKeyBytes != null)
			{
				string signature = GetSignature(uri);

				signatureParam = "&signature=" + signature;
			}

			return uri.Scheme + "://" + uri.Host + uri.LocalPath + uri.Query + signatureParam;
		}

		/// <summary>
		/// Appends proper ApiKey or ClientId and possibly the signature for the given Uri.  
		/// </summary>
		/// <remarks>
		/// Please note, If no usablePrivateKey specified in the constructor, then no signature can be generated.
		/// </remarks>
		/// <param name="uri"></param>
		/// <returns></returns>
		public string GetSignedUri(string url)
		{
			return GetSignedUri(new Uri(url));
		}

		/// <summary>
		/// Gets signature for the given uri.
		/// </summary>
		/// <param name="uri"></param>
		/// <returns></returns>
		public string GetSignature(Uri uri)
		{
			byte[] encodedPathQuery = Encoding.ASCII.GetBytes(uri.LocalPath + uri.Query);

			var hashAlgorithm = new HMACSHA1(_privateKeyBytes);
			byte[] hashed = hashAlgorithm.ComputeHash(encodedPathQuery);

			string signature = Base64_ForUrls(Convert.ToBase64String(hashed));
			return signature;
		}

		/// <summary>
		/// Gets signature for the given uri.
		/// </summary>
		/// <param name="uri"></param>
		/// <returns></returns>
		public string GetSignature(string url)
		{
			return GetSignature(new Uri(url));
		}

		/// <summary>
		/// Encodes a base64 string to be url-friendly.
		/// </summary>
		/// <param name="base64"></param>
		/// <returns></returns>
		static string Base64_ForUrls(string base64)
		{
			var sb = new StringBuilder(base64).Replace("+", "-").Replace("/", "_");
			return sb.ToString();
		}

	}

	/// <summary>
	/// Describes the way in which a Uri will be signed
	/// </summary>
	public enum GoogleSignedType
	{
		/// <summary>
		/// Indicates that the Uri will be signed using an API Key which would allow per key quotas.
		/// </summary>
		ApiKey,

		/// <summary>
		/// Indicates that the Uri will be signed using the business client id and allows the use of the business services.
		/// </summary>
		Business
	}
}
