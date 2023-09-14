﻿using System.Linq;

namespace Google.Maps.Internal
{
    internal static class StringCaseExtensions
    {
	    public static string ToSnakeCase(this string str) {
		    return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
	    }
	}
}
