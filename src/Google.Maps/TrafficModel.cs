namespace Google.Maps {
	/// <summary>
	/// Specifies the assumptions to use when calculating time in traffic. This setting affects the value returned in the duration_in_traffic field in the response,
	/// which contains the predicted time in traffic based on historical averages. The traffic_model parameter may only be specified for driving directions where
	/// the request includes a departure_time, and only if the request includes an API key or a Google Maps Platform Premium Plan client ID. 
	/// </summary>
	/// <see href="http://code.google.com/apis/maps/documentation/directions/#traffic_model"/>
	public enum TrafficModel {
		/// <summary>
		/// (default) indicates that the returned duration_in_traffic should be the best estimate of travel time given what is known about both historical
		/// traffic conditions and live traffic. Live traffic becomes more important the closer the departure_time is to now.
		/// </summary>
		best_guess,

		/// <summary>
		///  indicates that the returned duration_in_traffic should be longer than the actual travel time on most days, though occasional days with particularly bad traffic conditions may exceed this value
		/// </summary>
		pessimistic,

		/// <summary>
		/// indicates that the returned duration_in_traffic should be shorter than the actual travel time on most days, though occasional days with particularly good traffic conditions may be faster than this value.
		/// </summary>
		optimistic,

	}
}
