﻿using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Google.Maps.Common;

namespace Google.Maps.Direction
{
	[JsonObject(MemberSerialization.OptIn)]
	public class DirectionStep
	{
		[JsonProperty("travel_mode")]
		public TravelMode TravelMode { get; set; }

		[JsonProperty("start_location")]
		public LatLng StartLocation { get; set; }

		[JsonProperty("end_location")]
		public LatLng EndLocation { get; set; }

		[JsonProperty("polyline")]
		public Polyline Polyline { get; set; }

		[JsonProperty("duration")]
		public ValueText Duration { get; set; }

		[Obsolete("maneuver is obsolete", false)]
		public string Maneuver { get; set; }

		[JsonProperty("transit_details")]
		public DirectionTransitDetails TransitDetails { get; set; }

		[JsonProperty("html_instructions")]
		public string HtmlInstructions { get; set; }

		[JsonProperty("distance")]
		public ValueText Distance { get; set; }

		[JsonProperty("steps")]
		public DirectionStep[] Steps { get; set; }

		public DirectionStep() { }

		public DirectionStep(LatLng start, LatLng end)
		{
			StartLocation = start;
			EndLocation = end;
		}

		public DirectionStep(decimal startLat, decimal startLng, decimal endLat, decimal endLng)
		{
			StartLocation = new LatLng(startLat, startLng);
			EndLocation = new LatLng(endLat, endLng);
		}
	}
}
