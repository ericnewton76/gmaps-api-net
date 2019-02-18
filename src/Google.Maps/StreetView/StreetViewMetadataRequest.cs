
using System;

using Google.Maps.Internal;

namespace Google.Maps.StreetView
{
	/// <summary>
	/// The Google Static Maps API returns metadata about availablility
	/// in response to a HTTP request via a URL. For each request, you can
	/// specify the <see cref="StreetViewBase.Location"/> of the map, or <see cref="StreetViewBase.PanoramaId"/>,
	/// </summary>
	public class StreetViewMetadataRequest : StreetViewBase
	{
		public override Uri ToUri()
		{
			QueryStringBuilder qs = new QueryStringBuilder();

			if (this.Location != null)
			{
				qs.Append("location", this.Location.GetAsUrlParameter());
			}
			else if (string.IsNullOrEmpty(this.PanoramaId) == false)
			{
				qs.Append("pano", this.PanoramaId);
			}
			else
			{
				throw new InvalidOperationException("Either Location or PanoramaId property are required.");
			}

			var url = "streetview/metadata?" + qs.ToString();

			return new Uri(StreetViewService.HttpsUri, new Uri(url, UriKind.Relative));
		}
	}
}
