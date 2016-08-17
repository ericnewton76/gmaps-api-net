using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Maps
{
	internal static class Constants
	{
		public const int SIZE_WIDTH_MIN = 1;
		public const int SIZE_HEIGHT_MIN = 1;
		public const int SIZE_WIDTH_MAX = 4096;
		public const int SIZE_HEIGHT_MAX = 4096;

		public const int ZOOM_LEVEL_MIN = 0;

		public const string PATH_ENCODED_PREFIX = "enc:";
		public const string PIPE_URL_ENCODED = "%7C";

		public const string expectedColors = "black, brown, green, purple, yellow, blue, gray, orange, red, white"; //pasted straight from the website.

		private static string[] S_ExpectedNamedColors;
		public static bool IsExpectedNamedColor(string value)
		{
			if(value == null) return false;
			return (Contains(S_ExpectedNamedColors, value, true));
		}

		private static int[] S_ExpectedScaleValues;
		public static bool IsExpectedScaleValue(int value, bool throwIfOutOfRange)
		{
			if(Contains(S_ExpectedScaleValues, value) == true) return true;

			if(throwIfOutOfRange)
				throw new ArgumentOutOfRangeException("Scale value can only be " + ListValues(S_ExpectedScaleValues));
			else
				return false;
		}

		static Constants()
		{
			S_ExpectedNamedColors = expectedColors.Replace(", ", ",").Split(',');  //since we paste straight from the website, we remove spaces, and convert to an array.
			S_ExpectedScaleValues = new int[] { 1, 2, 4 };
		}

		#region Pre-Framework v3.0 support
		private static bool Contains(string[] array, string value, bool ignoreCase)
		{
			//TODO: rewrite for speed somehow
			for(int i = 0; i < array.Length; i++)
			{
				if(string.Compare(array[i], value, ignoreCase) == 0) return true;
			}

			return false;
		}
		private static bool Contains(int[] array, int value)
		{
			//TODO: rewrite for speed somehow
			for(int i = 0; i < array.Length; i++)
			{
				if(array[i] == value) return true;
			}

			return false;
		}
		private static string ListValues(int[] array)
		{
			//TODO: rewrite for speed somehow
			System.Text.StringBuilder sb = new StringBuilder();
			for(int i = 0; i < array.Length; i++)
			{
				if(sb.Length > 0) sb.Append(",");
				sb.Append(array[i]);
			}
			return sb.ToString();
		}
		#endregion

	}
}
