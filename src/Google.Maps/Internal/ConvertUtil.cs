using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Google.Maps.Internal
{
	internal static class ConvertUtil
	{


		public static bool TryCast<Tfrom, Tto>(IEnumerable<Tfrom> collection, out IEnumerable<Tto> convertedCollection) where Tto : class
		{
			IEnumerator collectionEnumerator = collection.GetEnumerator();

			List<Tto> target = new List<Tto>(collection.Count());

			while(collectionEnumerator.MoveNext())
			{
				if(collectionEnumerator.Current == null)
				{
					target.Add(null);
				}
				else
				{
					Tto convert = collectionEnumerator.Current as Tto;
					if(convert == null) { convertedCollection = null; return false; }
					target.Add(convert);
				}
			}

			convertedCollection = target;
			return true;
		}

	}
}
