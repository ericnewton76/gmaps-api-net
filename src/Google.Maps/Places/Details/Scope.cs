using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps.Places.Details
{
	public enum Scope
	{
		/// <summary>
		/// The place ID is recognised by your application only.
		/// This is because your application added the place,
		/// and the place has not yet passed the moderation process.
		/// </summary>
		APP,

		/// <summary>
		/// The place ID is available to other applications and on Google Maps.
		/// </summary>
		GOOGLE
	}
}
