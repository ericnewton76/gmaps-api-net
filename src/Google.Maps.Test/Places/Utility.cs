using NUnit.Framework;
using System.IO;

namespace Google.Maps.Test.Places
{
	class Utility
	{
		public static GoogleSigned GetRealSigningInstance()
		{
			try
			{
				using(var keys = new StreamReader(@"..\..\..\ServerSigningKeys.txt"))
				{
					var key = keys.ReadLine().Trim();

					return new GoogleSigned(key);
				}
			}
			catch(FileNotFoundException)
			{
				Assert.Ignore("ServerSigningKeys.txt could not be found - ignoring Places tests.");
				return null;
			}
		}
	}
}
