using System;

namespace Google.Maps
{
    /// <summary>
    /// Specifies the assumptions to use when calculating time in traffic.
    /// This setting affects the value returned in the duration_in_traffic field in the response, which contains the predicted time in traffic based on historical averages.
    /// The traffic_model parameter may only be specified for requests where the travel mode is driving, and where the request includes a departure_time, and only if the request includes an API key or a Google Maps Platform Premium Plan client ID. 
    /// </summary>
    [Flags]
	public enum TransitRoutingPreferences
	{
		/// <summary>
		/// indicates that the calculated route should prefer limited amounts of walking.
		/// </summary>
		less_walking = 0,
		/// <summary>
		/// indicates that the calculated route should prefer a limited number of transfers.
		/// </summary>
		fewer_transfers = 1,

	}
}
