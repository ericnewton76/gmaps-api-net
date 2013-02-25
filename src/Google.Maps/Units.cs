using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Maps
{
	/// <summary>
	///  When you calculate Directions Matrix, you may specify which Unit system mode to use. 
	///  By default, directions are showes as metric. The following units system modes are currently supported:
	/// </summary>
	public enum Units
	{
		/// <summary>
		/// (default) Returns distances in kilometers and meters
		/// </summary>
		metric,

		/// <summary>
		///  returns distances in miles and feet
		/// </summary>
		imperial
	}
}
