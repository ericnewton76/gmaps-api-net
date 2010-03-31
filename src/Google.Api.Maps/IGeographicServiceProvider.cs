namespace Google.Api.Maps
{
    public interface IGeographicServiceProvider
    {
        Location[] FindLocation(string name);
        Location[] FindLocation(GeographicPoint coordinates);

        T[] FindLocationAs<T>(string name) where T : Location, new();
        T[] FindLocationAs<T>(GeographicPoint coordinates) where T : Location, new();
    }
}
