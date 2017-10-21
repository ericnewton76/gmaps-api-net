# Google Maps API for .NET

[![Build status](https://ci.appveyor.com/api/projects/status/ni8ha94ofk7acjmf/branch/master)](https://ci.appveyor.com/project/EricNewton/gmaps-api-net)

A .NET library for interacting with the Google Maps API suite.

NuGet package: https://www.nuget.org/packages/gmaps-api-net/
```
PS> Install-Package gmaps-api-net
```

## Overview
This project attempts to provide all the features available in the Google Maps API. It is being developed in C# for the Microsoft .NET Framework v3.5 and up. *gmaps-api-net* is a fully featured API client library, providing strongly typed access to the API.

## API Support

Currently the library supports full coverage of the following Google Maps APIs:
  * Geocoding
  * Elevation
  * Static Maps
  * Directions
  * Distance Matrix
  * Places
  * Time Zones
  * Street View, added to v0.19

## Quick Examples
Using Google Maps API for .NET is designed to be really easy.

### Getting an address from the Geocoding service
Let's suppose we want to search an address and get more information about it. We can write:

```c#
var request = new GeocodingRequest();
request.Address = "1600 Amphitheatre Parkway";
request.Sensor = false;
var response = new GeocodingService().GetResponse(request);
```

The `GeocodingService` class submits the request to the API web service, and returns 
the response strongly typed as a `GeocodeResponse` object which may contain zero, one or more results. 
Assuming we received at least one result, let's get some of its properties:

```c#
var result = response.Results.First();

Console.WriteLine("Full Address: " + result.FormattedAddress);         // "1600 Amphitheatre Pkwy, Mountain View, CA 94043, USA"
Console.WriteLine("Latitude: " + result.Geometry.Location.Latitude);   // 37.4230180
Console.WriteLine("Longitude: " + result.Geometry.Location.Longitude); // -122.0818530
```

### Getting a static map URL
Static Maps support allows you to get a valid url which you can use, for example, with an `<img src="">` tag.

```c#
var map = new StaticMapRequest();
map.Center = new Location("1600 Amphitheatre Parkway Mountain View, CA 94043");
map.Size = new System.Drawing.Size(400, 400);
map.Zoom = 14;
map.Sensor = false;

var imgTagSrc = map.ToUri();
```

### Using a Google Maps for Business key

```c#
GoogleSigned.AssignAllServices(new GoogleSigned("gme-your-client-id", "your-signing-key"));

// Then do as many requests as you like...
var request = new GeocodingRequest { Address="1600 Amphitheatre Parkway", Sensor = false };
var response = GeocodingService.GetResponse(request);
```

### Using a Google Maps API key

```c#
GoogleSigned.AssignAllServices(new GoogleSigned("your-api-key"));

// Then do as many requests as you like...
var request = new GeocodingRequest { Address="1600 Amphitheatre Parkway", Sensor = false };
var response = GeocodingService.GetResponse(request);
```

## Contact
Questions, comments and/or suggestions are welcome! Please raise an [issue](https://github.com/ericnewton76/gmaps-api-net/issues) in GitHub or send an email to:

- Eric Newton [ericnewton76@gmail.com](mailto:ericnewton76@gmail.com)
- Richard Thombs [stonyuk@gmail.com](mailto:stonyuk@gmail.com)

## Contributors
A big thank you to all of our [contributors](https://github.com/ericnewton76/gmaps-api-net/graphs/contributors) including:

- [Eric Newton](https://github.com/ericnewton76)
- [Sheepzez](https://github.com/Sheepzez)
- [Mieliespoor](https://github.com/mieliespoor)
- [Richard Thombs](https://github.com/richardthombs)
- [Frank Hommers](https://github.com/frankhommers)
- [Maetiz](https://github.com/Maetiz)
- [obito1406](https://github.com/obito1406)
- [pettys](https://github.com/pettys)

Forked from a work originally created by [Luis Farzati](https://github.com/luisfarzati) and incorporating ideas from [Brian Pedersen](https://briancaos.wordpress.com/2009/10/16/google-maps-polyline-encoding-in-c)

## A note to Contributors
In order to maintain the project files' formatting, please get the EditorConfig plugin that works with your favorite IDE. Many options available.  

This will go a long ways towards helping to maintain formatting so that actual changes arent lost in formatting changes... And that's a good thing, yes?  :wink:

The .editorconfig file specifies the desired formatting.  It basically uses an out-of-the-box Visual Studio 2013 C# editor configuration.

And to all who contribute... *Thank you!*
