using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps
{
	public class LatLngComparer : IEqualityComparer<LatLng>
	{

		public static LatLngComparer Within(float epsilon)
		{
			return new LatLngComparer(epsilon);
		}

		private LatLngComparer(float epsilon)
		{
			this._epsilon = epsilon;
		}

		Single _epsilon;
		public Single Epsilon { get { return this._epsilon; } }

		public bool Equals(LatLng x, LatLng y)
		{
			if(x == null || y == null) return false;

			if(this.Equals(x.Latitude, y.Latitude, this._epsilon) == false)
				return false;

			if(this.Equals(x.Longitude, y.Longitude, this._epsilon) == false)
				return false;

			return true;
		}

		public int GetHashCode(LatLng value)
		{
			return value.Latitude.GetHashCode() ^ value.Longitude.GetHashCode();
		}

		private bool Equals(double a, double b, float epsilonParam)
		{
			double epsilon = Convert.ToDouble(epsilonParam);
			double absA = Math.Abs(a);
			double absB = Math.Abs(b);
			double diff = Math.Abs(a - b);

			if(a * b == 0)
			{ // a or b or both are zero
				// relative error is not meaningful here
				return diff < (epsilon * epsilon);
			}
			else
			{ // use relative error
				return diff / (absA + absB) < epsilon;
			}
		}

	}
}
