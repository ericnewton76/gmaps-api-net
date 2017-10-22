using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Maps.Test
{
    public static class Helpers
    {
		public static Dictionary<string, string> ParseQueryString(string querystring)
		{
			Dictionary<string, string> values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

			int indexOfQmark = querystring.IndexOf("?");

			if(indexOfQmark > -1)
			{
				querystring = querystring.Substring(indexOfQmark + 1);
			}

			string[] kvpairs = querystring.Split('&');
			foreach(var keyequalvalue in kvpairs)
			{
				string[] kv = keyequalvalue.Split('=');
				values[kv[0]] = kv[1];

			}

			return values;
		}
	}
}
