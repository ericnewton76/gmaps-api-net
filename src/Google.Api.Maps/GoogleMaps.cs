using System.Linq;
using Google.Api.Maps.Service.Geocoding;

namespace Google.Api.Maps
{
    public class GoogleMaps : IGeographicServiceProvider
    {
        #region IGeographicServiceProvider Members

        public Location[] FindLocation(string name)
        {
            return FindLocationAs<Location>(name);
        }

        public Location[] FindLocation(GeographicPoint coordinates)
        {
            return FindLocationAs<Location>(coordinates);
        }

        public T[] FindLocationAs<T>(string name) where T : Location, new()
        {
            return GeocodingService
                .GetResponse(new GeocodingRequest(name, "false"))
                .Results
                .ToLocationArray()
                .Select<Location, T>(t =>
                    new T()
                    {
                        Components = t.Components,
                        Coordinates = t.Coordinates,
                        Name = t.Name,
                        Precision = t.Precision
                    }
                )
                .ToArray();
        }

        public T[] FindLocationAs<T>(GeographicPoint coordinates) where T : Location, new()
        {
            return GeocodingService
                .GetResponse(new GeocodingRequest(coordinates.Latitude.ToString(), coordinates.Longitude.ToString(), "false"))
                .Results
                .ToLocationArray()
                .Select<Location, T>(t =>
                    new T()
                    {
                        Components = t.Components,
                        Coordinates = t.Coordinates,
                        Name = t.Name,
                        Precision = t.Precision
                    }
                )
                .ToArray();
        }

        #endregion

        public Address[] FindAddress(string address)
        {
            return FindLocationAs<Address>(address);
        }
    }
}
