using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Api.Maps.Service.Geocoding;

namespace Google.Api.Maps
{
    public static class Extensions
    {
        public static AddressComponent[] HavingType(this AddressComponent[] array, AddressType type)
        {
            return (from component in array
                    where component.Types.Any(t => t == type)
                    select component).ToArray();
        }

        public static Precision ToPrecision(this LocationType serviceSpecificEnum)
        {
            Precision result;

            switch (serviceSpecificEnum)
            {
                case LocationType.Approximate:
                    result = Precision.Approximate;
                    break;
                case LocationType.GeometricCenter:
                    result = Precision.Centered;
                    break;
                case LocationType.RangeInterpolated:
                    result = Precision.Interpolated;
                    break;
                case LocationType.Rooftop:
                    result = Precision.Exact;
                    break;
                case LocationType.Unknown:
                default:
                    result = Precision.Unknown;
                    break;
            }

            return result;
        }

        public static Location[] ToLocationArray(this GeocodingResult[] serviceSpecificResults)
        {
            var locations = (from result in serviceSpecificResults
                             select new Location
                             {
                                 Name = result.FormattedAddress,
                                 Coordinates = result.Geometry.Location.ToGeographicPoint(),
                                 Precision = result.Geometry.LocationType.ToPrecision(),
                                 Components = result.Components
                             }).ToArray();

            return locations;
        }

        public static GeographicPoint ToGeographicPoint(this GeographicPosition serviceSpecificCoordinates)
        {
            return new GeographicPoint(serviceSpecificCoordinates.Latitude, serviceSpecificCoordinates.Longitude);
        }
    }
}
