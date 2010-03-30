using Google.Api.Maps.Service;
using Google.Api.Maps.Service.Geocoding;
using System.Collections.Generic;
using System;

namespace Google.Api.Maps
{
    public struct Coordinate
    {
        private decimal decimalDegrees;

        public int Degrees
        {
            get
            {
                return (int)Math.Floor(Math.Abs(decimalDegrees));
            }
            set
            {

            }
        }

    }

    public struct GeographicPoint
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Elevation { get; set; }
    }

    public class Location
    {
        public LocationType Precision { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }

    public class Address : Location
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public int? Floor { get; set; }
        public string Room { get; set; }
        public Dictionary<AddressType,Location> AdministrativeArea { get; set; }
        public Location Country { get; set; }
    }

    public class ApproximateAddress : Location
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public int? Floor { get; set; }
        public string Room { get; set; }
        public Dictionary<AddressType, Location> AdministrativeArea { get; set; }
        public Location Country { get; set; }
    }

    public class Map
    {
        public Location Location { get; set; }
    }
}
