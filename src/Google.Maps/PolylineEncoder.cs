/* code reused from SoulSolutions */
/* retrieved from http://briancaos.wordpress.com/2009/10/16/google-maps-polyline-encoding-in-c/ */
/* implements the Polyline Encoding Algorithm as defined at
 * http://code.google.com/apis/maps/documentation/utilities/polylinealgorithm.html
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Maps
{
	public class PolylineEncoder
	{
		/// <summary>
		/// Encodes the list of coordinates to a Google Maps encoded coordinate string.
		/// </summary>
		/// <param name="coordinates">The coordinates.</param>
		/// <returns>Encoded coordinate string</returns>
		public static string EncodeCoordinates(IEnumerable<LatLng> coordinates)
		{
			double oneEFive = Convert.ToDouble(1e5);

			int plat = 0;
			int plng = 0;
			StringBuilder encodedCoordinates = new StringBuilder();

			foreach(LatLng coordinate in coordinates)
			{
				// Round to 5 decimal places and drop the decimal
				int late5 = (int)(coordinate.Latitude * oneEFive);
				int lnge5 = (int)(coordinate.Longitude * oneEFive);

				// Encode the differences between the coordinates
				encodedCoordinates.Append(EncodeSignedNumber(late5 - plat));
				encodedCoordinates.Append(EncodeSignedNumber(lnge5 - plng));

				// Store the current coordinates
				plat = late5;
				plng = lnge5;
			}

			return encodedCoordinates.ToString();
		}

		/// <summary>
		/// Decode encoded polyline information to a collection of <see cref="LatLng"/> instances.
		/// </summary>
		/// <param name="value">ASCII string</param>
		/// <returns></returns>
		public static IEnumerable<LatLng> Decode(string value)
		{
			//decode algorithm adapted from saboor awan via codeproject:
			//http://www.codeproject.com/Tips/312248/Google-Maps-Direction-API-V3-Polyline-Decoder
			//note the Code Project Open License at http://www.codeproject.com/info/cpol10.aspx

			if(value == null || value == "") return new List<LatLng>(0);

			char[] polylinechars = value.ToCharArray();
			int index = 0;

			int currentLat = 0;
			int currentLng = 0;
			int next5bits;
			int sum;
			int shifter;

			List<LatLng> poly = new List<LatLng>();

			while(index < polylinechars.Length)
			{
				// calculate next latitude
				sum = 0;
				shifter = 0;
				do
				{
					next5bits = (int)polylinechars[index++] - 63;
					sum |= (next5bits & 31) << shifter;
					shifter += 5;
				} while(next5bits >= 32 && index < polylinechars.Length);

				if(index >= polylinechars.Length)
					break;

				currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

				//calculate next longitude
				sum = 0;
				shifter = 0;
				do
				{
					next5bits = (int)polylinechars[index++] - 63;
					sum |= (next5bits & 31) << shifter;
					shifter += 5;
				} while(next5bits >= 32 && index < polylinechars.Length);

				if(index >= polylinechars.Length && next5bits >= 32)
					break;

				currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);
				LatLng point = new LatLng(
					latitude: Convert.ToDouble(currentLat) / 100000.0,
					longitude: Convert.ToDouble(currentLng) / 100000.0
				);
				poly.Add(point);
			}

			return poly;
		}

		/// <summary>
		/// Encode a signed number in the encode format.
		/// </summary>
		/// <param name="num">The signed number</param>
		/// <returns>The encoded string</returns>
		private static string EncodeSignedNumber(int num)
		{
			int sgn_num = num << 1; //shift the binary value
			if(num < 0) //if negative invert
			{
				sgn_num = ~(sgn_num);
			}
			return (EncodeNumber(sgn_num));
		}

		/// <summary>
		/// Encode an unsigned number in the encode format.
		/// </summary>
		/// <param name="num">The unsigned number</param>
		/// <returns>The encoded string</returns>
		private static string EncodeNumber(int num)
		{
			StringBuilder encodeString = new StringBuilder();
			while(num >= 0x20)
			{
				encodeString.Append((char)((0x20 | (num & 0x1f)) + 63));
				num >>= 5;
			}
			encodeString.Append((char)(num + 63));
			// All backslashes needs to be replaced with double backslashes
			// before being used in a Javascript string.
			return encodeString.ToString();
		}
	}
}
