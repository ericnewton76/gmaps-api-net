using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

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
		/// <summary>
		/// Used by all the services except Geolocation API and Places API
		/// </summary>
		private static GoogleSigned S_universalSigningInstance;

		/// <summary>
		/// Gets or sets the GoogleSigned instance to use for all of the various service calls.
		/// </summary>
		public static GoogleSigned SigningInstance 
		{
			get { return S_universalSigningInstance; }
		}
		/// <summary>
		/// Assigns the given SigningInstance to all services that can utilize it.  Note that some of the services do not currently use the signature method.
		/// </summary>
		/// <param name="signingInstance"></param>
		public static void AssignAllServices(GoogleSigned signingInstance)
		{
			S_universalSigningInstance = signingInstance;
			//Direction.DirectionService.SigningInstance = signingInstance;
			//DistanceMatrix.DistanceMatrixService.SigningInstance = signingInstance;
			//Elevation.ElevationService.SigningInstance = signingInstance;
			//Geocoding.GeocodingService.SigningInstance = signingInstance;
			//StaticMaps.StaticMapService.SigningInstance = signingInstance;
		}

		public GoogleSigned(string clientId, string usablePrivateKey)
		{
			usablePrivateKey = usablePrivateKey.Replace("-", "+").Replace("_","/");

			_privateKeyBytes = Convert.FromBase64String(usablePrivateKey);

			_clientId = clientId;
		}

		private byte[] _privateKeyBytes;
		private string _clientId;
		public string ClientId { get { return _clientId; } }

		public string GetSignedUri(Uri uri)
		{
			var builder = new UriBuilder(uri);
			builder.Query = builder.Query.Substring(1) + "&client=" + _clientId;
			uri = builder.Uri;

			string signature = GetSignature(uri);
			signature = signature.Replace("+", "-").Replace("/", "_");

			return uri.Scheme + "://" + uri.Host + uri.LocalPath + uri.Query + "&signature=" + signature;
		}
		public string GetSignedUri(string url)
		{
			return GetSignedUri(new Uri(url));
		}

		public string GetSignature(Uri uri)
		{
			byte[] encodedPathQuery = Encoding.ASCII.GetBytes(uri.LocalPath + uri.Query);

            var hashAlgorithm = new HMACSHA1(_privateKeyBytes);
            byte[] hashed = hashAlgorithm.ComputeHash(encodedPathQuery);

			string signature = Convert.ToBase64String(hashed);
			return signature;
		}
		public string GetSignature(string url)
		{
			return GetSignature(new Uri(url));
		}


	}

}
