using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps.Internal
{
	internal static class RequestUtils
	{

		public static string GetLatLngCollectionStr(IEnumerable<LatLng> locationsCollection, int encodedPolylineThreshold = 3)
		{
			if(locationsCollection == null) return null;

			int countOfItems = locationsCollection.Count();
			if(countOfItems >= encodedPolylineThreshold)
			{
				return Constants.PATH_ENCODED_PREFIX + PolylineEncoder.EncodeCoordinates(locationsCollection);
			}
			else
			{
				System.Text.StringBuilder sb = new StringBuilder(countOfItems * 22); // normally latlng's are -40.454545,-90.454545 so I picked a "larger than average" of 22 digits.
				foreach(LatLng position in locationsCollection)
				{
					if(sb.Length > 0) sb.Append("|");
					sb.Append(position.GetAsUrlParameter());
				}

				return sb.ToString();
			}
		}

	}
}
