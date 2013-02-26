using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps.Test
{
	public class ValueTextComparer : IComparer<ValueText>
	{

		public ValueTextComparer(StringComparer stringComparer)
		{
			this._stringComparer = stringComparer;
		}

		private StringComparer _stringComparer;


		public int Compare(ValueText x, ValueText y)
		{
			if (x == null && y == null) return 0;

			int test;

			test = this._stringComparer.Compare(x.Text, y.Text);
			if (test != 0) return test;

			test = this._stringComparer.Compare(x.Value, y.Value);
			if (test != 0) return test;

			//i guess they're the same.
			return 0;
		}
	}
}
