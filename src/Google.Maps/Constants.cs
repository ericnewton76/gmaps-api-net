using System;
using System.Collections.Generic;
using System.Linq;
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
            if (value == null) return false;
            return (S_ExpectedNamedColors.Contains(value, StringComparer.OrdinalIgnoreCase));
        }

		private static int[] S_ExpectedScaleValues;
		public static bool IsExpectedScaleValue(int value, bool throwIfOutOfRange)
		{
			if (S_ExpectedScaleValues.Contains(value) == true) return true;

			if (throwIfOutOfRange) 
				throw new ArgumentOutOfRangeException("Scale value can only be " + String.Join(",", S_ExpectedScaleValues.Select(_=>_.ToString()).ToArray()));
			else
				return false;
		}

        static Constants()
        {
            S_ExpectedNamedColors =expectedColors.Replace(", ", ",").Split(',');  //since we paste straight from the website, we remove spaces, and convert to an array.
			S_ExpectedScaleValues = new int[] { 1, 2, 4 };
        }
    }
}
