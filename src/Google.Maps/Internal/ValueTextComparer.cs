using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps
{
	public class ValueTextComparer : IComparer<ValueText>
	{
		public ValueTextComparer(StringComparer stringComparer)
		{
			if(stringComparer == null) throw new ArgumentNullException("stringComparer");
			this._stringComparer = stringComparer;
		}

		private StringComparer _stringComparer;

		public int Compare(ValueText x, ValueText y)
		{
			if(x == null) return -1;
			if(y == null) return 1;

			int test;

			test = this._stringComparer.Compare(x.Text, y.Text);
			if(test != 0) return test;

			if(x.Value < y.Value) return -1;
			if(x.Value > y.Value) return 1;

			//i guess they're the same.
			return 0;
		}
	}
}
