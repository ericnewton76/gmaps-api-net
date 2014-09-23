# Google Maps API for .NET

[![Build status](https://ci.appveyor.com/api/projects/status/ni8ha94ofk7acjmf)](https://ci.appveyor.com/project/EricNewton/gmaps-api-net)

C# google maps api interface for interacting with the backend web services for Google Maps

This is the main repository for the Google Maps API for .Net

Nuget package: https://www.nuget.org/packages/gmaps-api-net/
```
PS> Install-Package gmaps-api-net
```

## Overview
This project intends to provide all the features available in the Google Maps API up to v3.7. It is being developed in C# for .NET Framework 3.5.

* Please note that this project is still in design and development phase; the libraries may suffer major changes even at the interface level, so don't rely (yet) in this software for production uses. *

Designed with simplicity and extensibility in mind, there are different libraries according to what you need.

*Google.Maps* is a full featured API client library, providing strongly typed access to the API.  

## API Support

Currently the service library supports full coverage of the following Google Maps APIs:
  * *Geocoding*
  * *Elevation*
  * *Static Maps*
  * *Direction* (thanks to malke.eklam)
  * *Direction Matrix* (thanks to mocciavinc...@gmail.com)
  * *Polyline encoding* (code based on source from [http://bit.ly/5XuDqb  briancaos.wordpress.com])
  * *Google Maps for Business support*, using Google-supplied Client ID and private key for generating signed urls. (thanks for test generation and other help from richardthombs)

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

The 'GeocodingService' class submits the request to the API web service, and returns 
the response strongly typed as a `GeocodeResponse` object which may contain zero, one or more results. 
Assuming we received at least one result, let's get some of its properties:

```c#
var result = response.Results.First();

Console.WriteLine("Full Address: " + result.FormattedAddress);         // "1600 Amphitheatre Pkwy, Mountain View, CA 94043, USA"
Console.WriteLine("Latitude: " + result.Geometry.Location.Latitude);   // 37.4230180
Console.WriteLine("Longitude: " + result.Geometry.Location.Longitude); // -122.0818530
```

### Getting a static map url
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


## Project Roadmap
The roadmap has changed a little with changing of hands, but the basic premise is the same.  
  * ~~*Geocoding API*~~
  * ~~*Elevation API*~~
  * *Static Maps* (WORKING)
  * *Documentation!* (WORKING)
  * *Sample code* (WORKING)
  * *Higher level API classes* (WORKING)
  * *Cacheability support* (WORKING)
  * *HTML helpers* -will be implemented in a tandem project for MVC and WebForms
  * *Cache implementation*
  * *Smart address search*

## Contact
Questions, comments and/or suggestions are welcome! You can send an email to 
- Luis at [mailto:luisfarzati@katulu.net luisfarzati@katulu.net], or Twitter: [http://twitter.com/luisfarzati]
- Eric Newton [mailto:ericnewton76@gmail.com ericnewton76@gmail.com]

*Thank you!*
