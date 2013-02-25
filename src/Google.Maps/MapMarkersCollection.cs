using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Maps
{

	/// <summary>
	/// Contains a collection of <see cref="MapMarkers" />.
	/// </summary>
	public class MapMarkersCollection : List<MapMarkers>
	{
		public void Add(Location value)
		{
			MapMarkers m = new MapMarkers();
			m.Locations.Add(value);
			base.Add(m);
		}

		//public static implicit operator MarkersCollection(LatLng value)
		//{
		//    MapMarkers m=new MapMarkers();
		//    m.Locations.Add(value);

		//    MarkersCollection c = new MarkersCollection();
		//    c.Add(m);

		//    return c;
		//}
		//public static implicit operator MarkersCollection(Location value)
		//{
		//    MapMarkers m = new MapMarkers();
		//    m.Locations.Add(value);

		//    MarkersCollection c = new MarkersCollection();
		//    c.Add(m);

		//    return c;
		//}


	}
}
