using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Maps
{
	/// <summary>
	/// When you calculate directions, you may specify which transportation mode to use. By default, directions are calculated as driving directions. The following travel modes are currently supported:
	/// Note: Both walking and bicycling directions may sometimes not include clear pedestrian or bicycling paths, so these directions will return warnings in the returned result which you must display to the user.
	/// </summary>
	/// <see cref="http://code.google.com/apis/maps/documentation/directions/#TravelModes"/>
	public enum TravelMode
	{
		/// <summary>
		/// (default) indicates standard driving directions using the road network.
		/// </summary>
		driving,

		/// <summary>
		/// requests walking directions via pedestrian paths & sidewalks (where available).
		/// </summary>
		walking,

		/// <summary>
		/// requests bicycling directions via bicycle paths & preferred streets (currently only available in the US).
		/// </summary>
		bicycling,

		/// <summary>
		/// requests public transportation directions (where available).
		/// </summary>
		transit
	}
}
