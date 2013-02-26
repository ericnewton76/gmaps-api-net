using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Google.Maps.Direction
{
	public class DirectionService
	{
		public static readonly Uri HttpUri =
			new Uri("http://maps.googleapis.com/maps/api/directions/");
		public static readonly Uri HttpsUri =
			new Uri("https://maps.googleapis.com/maps/api/directions/");

		public DirectionService() : this(HttpsUri)
		{
		}
		public DirectionService(Uri baseUri)
		{
			this.BaseUri = HttpsUri;
		}

		public Uri BaseUri { get; set; }

		public DirectionResponse GetResponse(DirectionRequest request)
		{
			var url = new Uri(this.BaseUri, request.ToUri());
			return Internal.Http.Get(url).As<DirectionResponse>();
		}
	}
}
