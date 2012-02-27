using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Google.Maps.Geocoding;

namespace SearchAddressMap
{
	internal static class Extensions
	{
		public static TreeViewItem[] ToTree(this GeocodingResult[] results)
		{
			var nodes = new List<TreeViewItem>();

			foreach (var result in results)
			{
				var node = new TreeViewItem();
				node.Header = "(" + result.Types.FirstOrDefault() + ") " + result.FormattedAddress;
				node.Tag = result.Geometry.Location;

				foreach (var component in result.Components)
				{
					node.Items.Add(new TreeViewItem
					{
						Header = component.Types.FirstOrDefault() + ": " + component.LongName,
						Tag = result.Geometry.Location
					});
				}

				node.Items.Add(new TreeViewItem{ Header = "Lat: " + result.Geometry.Location.Latitude });
				node.Items.Add(new TreeViewItem { Header = "Lng: " + result.Geometry.Location.Longitude });

				nodes.Add(node);
			}

			return nodes.ToArray();
		}
	}
}
