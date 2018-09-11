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

		/// <summary>
		/// Converts the current request parameters to a uri
		/// </summary>
		/// <returns></returns>
		public abstract Uri ToUri();

		/// <summary>
		/// Returns the Uri as a string.
		/// </summary>
		/// <returns></returns>
		public string ToUriString()
		{
			return this.ToUri().ToString();
		}


	}
}
