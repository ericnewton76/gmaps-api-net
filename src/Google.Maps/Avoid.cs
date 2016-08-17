using System;

namespace Google.Maps
{
	/// <summary>
	/// Directions may be calculated that adhere to certain restrictions.
	/// Restrictions are indicated by use of the avoid parameter, and an
	/// argument to that parameter indicating the restriction to avoid.
	/// </summary>
	[Flags]
	public enum Avoid
	{
		/// <summary>
		///
		/// </summary>
		none = 0,

		/// <summary>
		///
		/// </summary>
		highways = 1,

		/// <summary>
		///
		/// </summary>
		tolls = 2,

		/// <summary>
		///
		/// </summary>
		ferries = 4

	}
}
