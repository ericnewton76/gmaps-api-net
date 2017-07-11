using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps
{
	public abstract class BaseRequest
	{
		[Obsolete("The Google Maps API no longer requires this parameter and it will be removed in the next release")]
		public bool? Sensor { get; set; }

		public abstract Uri ToUri();
	}
}
