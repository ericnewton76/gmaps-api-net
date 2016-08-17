using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps
{
	/// <summary>
	/// In a geocoding response, the Google Maps Geocoding API can return address results restricted to a specific area.
	/// The restriction is specified using the components filter. A filter consists of a list of component:value pairs separated
	/// by a pipe (|). Only the results that match all the filters will be returned. Filter values support the same methods of
	/// spelling correction and partial matching as other geocoding requests. If a geocoding result is a partial match for a
	/// component filter it will contain a partial_match field in the response.
	/// </summary>
	public class ComponentFilter
	{
		private Dictionary<string, string> parameters = new Dictionary<string, string>();

		/// <summary>
		/// Matches long or short name of a route.
		/// </summary>
		public string Route
		{
			get
			{
				return TryGetParameter("route");
			}
			set
			{
				parameters["route"] = value;
			}
		}

		/// <summary>
		/// Matches against both locality and sublocality types.
		/// </summary>
		public string Locality
		{
			get
			{
				return TryGetParameter("locality");
			}
			set
			{
				parameters["locality"] = value;
			}
		}

		/// <summary>
		/// Matches all the administrative_area levels.
		/// </summary>
		public string AdministrativeArea
		{
			get
			{
				return TryGetParameter("administrative_area");
			}
			set
			{
				parameters["administrative_area"] = value;
			}
		}

		/// <summary>
		/// Matches postal_code and postal_code_prefix.
		/// </summary>
		public string PostalCode
		{
			get
			{
				return TryGetParameter("postal_code");
			}
			set
			{
				parameters["postal_code"] = value;
			}
		}

		/// <summary>
		/// Matches a country name or a two letter ISO 3166-1 country code.
		/// </summary>
		public string Country
		{
			get
			{
				return TryGetParameter("country");
			}
			set
			{
				parameters["country"] = value;
			}
		}

		/// <summary>
		/// Converts filter to Url string.
		/// </summary>
		internal string ToUrlParameters()
		{
			var parametersList = parameters.Where(p => !(string.IsNullOrEmpty(p.Value) || p.Value.Trim().Length == 0)).Select(p => p.Key + ":" + p.Value);
			var parametersListFlatten = string.Join("|", parametersList.ToArray());

			return Uri.EscapeDataString(parametersListFlatten);
		}

		private string TryGetParameter(string key)
		{
			string route = null;
			parameters.TryGetValue(key, out route);

			return route;
		}

		/// <summary>
		/// implicitly converts a System.String to Google.Maps.ComponentFilter
		/// </summary>
		/// <param name="components">A filter consists of a list of component:value pairs separated by a pipe (|). For exemple: \"country:ES|locality:Santa Cruz de Tenerife\".</param>
		/// <returns></returns>
		public static implicit operator ComponentFilter(string components)
		{
			if(string.IsNullOrEmpty(components) || components.Trim().Length == 0)
			{
				return null;
			}

			var componentFilter = new ComponentFilter();
			var filters = components.Split('|');

			foreach(var filter in filters)
			{
				var filterSplitted = filter.Split(':');

				if(filterSplitted.Length != 2)
				{
					throw new ArgumentException("One of the filters is not well formated. Make sure that each filter is written \"component:value\" and are separated by \"|\". For exemple, \"country:ES|locality:Santa Cruz de Tenerife\"", "components");
				}

				var component = filterSplitted[0];
				var value = filterSplitted[1];

				switch(component.ToLowerInvariant())
				{
					case "route":
						componentFilter.Route = value;
						break;
					case "locality":
						componentFilter.Locality = value;
						break;
					case "administrative_area":
						componentFilter.AdministrativeArea = value;
						break;
					case "postal_code":
						componentFilter.PostalCode = value;
						break;
					case "country":
						componentFilter.Country = value;
						break;
					default:
						throw new ArgumentException("The value '" + component + "' is not a valid component.", "components");
				}
			}

			return componentFilter;
		}
	}
}
