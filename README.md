# Google Maps API for .NET

[![AppVeyor](https://img.shields.io/appveyor/ci/EricNewton/gmaps-api-net.svg)](https://ci.appveyor.com/project/EricNewton/gmaps-api-net)
[![Nuget](https://img.shields.io/nuget/v/gmaps-api-net.svg)](https://www.nuget.org/packages/gmaps-api-net/)
[![Join the chat at https://gitter.im/gmaps-api-net/Lobby](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/gmaps-api-net/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

A .NET library for interacting with the Google Maps API suite.

NuGet package: https://www.nuget.org/packages/gmaps-api-net/
```
PS> Install-Package gmaps-api-net
```

## Overview
This project attempts to provide all the features available in the Google Maps API. It is being developed in C# for the Microsoft .NET including .Net Framework v4.6.1+ and .Net Standard v1.3+. *gmaps-api-net* is a fully featured API client library, providing strongly typed access to the API.

## Notable Upcoming 
* Trying to achieve a formal v1.0 release for 2018. This is basically on-track for first week of January. File any major issues quickly to get addressed before v1.0!
* Planning a slight namespace/usage change for v2.0 release soon thereafter to support dependency injection and mocking away the library in your own testing apparatus.  Intention here is to isolate away the library returning values to returning known values during your testing. See branch [feat/support-dependency-injection](https://github.com/ericnewton76/gmaps-api-net/tree/feat/support-dependency-injection)
* In relation to above, we will begin removing our tests for specific values, and testing instead for schema changes that Google is pushing through.

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

### Quick Note about the Google Maps API Key
Google is now requiring a proper API key for accessing the service. Create a key [here](https://developers.google.com/maps/documentation/geocoding/get-api-key), or create/find an existing one in your Google Developers Console.

### Getting an address from the Geocoding service
Let's suppose we want to search an address and get more information about it. We can write:

```c#
//always need to use YOUR_API_KEY for requests.  Do this in App_Start.
GoogleSigned.AssignAllServices(new GoogleSigned("YOUR_API_KEY"));

var request = new GeocodingRequest();
request.Address = "1600 Pennsylvania Ave NW, Washington, DC 20500";
var response = new GeocodingService().GetResponse(request);

//The GeocodingService class submits the request to the API web service, and returns the
//response strongly typed as a GeocodeResponse object which may contain zero, one or more results.

//Assuming we received at least one result, let's get some of its properties:
if(response.Status == ServiceResponseStatus.Ok && response.Results.Count() > 0)
{
    var result = response.Results.First();

    Console.WriteLine("Full Address: " + result.FormattedAddress);         // "1600 Pennsylvania Ave NW, Washington, DC 20500, USA"
    Console.WriteLine("Latitude: " + result.Geometry.Location.Latitude);   // 38.8976633
    Console.WriteLine("Longitude: " + result.Geometry.Location.Longitude); // -77.0365739
    Console.WriteLine();
}
else
{
    Console.WriteLine("Unable to geocode.  Status={0} and ErrorMessage={1}", response.Status, response.ErrorMessage);
}
```

### Getting a static map URL
Static Maps API support allows you to get a valid url or a streamed bitmap which you can use:

```c#
//always need to use YOUR_API_KEY for requests.  Do this in App_Start.
GoogleSigned.AssignAllServices(new GoogleSigned("YOUR_API_KEY"));
var map = new StaticMapRequest();
map.Center = new Location("1600 Pennsylvania Ave NW, Washington, DC 20500");
map.Size = new System.Drawing.Size(400, 400);
map.Zoom = 14;
```

Sample for ASP.Net WebForms:

```c#
//Web Forms: Page method contains above code to create the request
var hyperlink = (Hyperlink)Page.FindControl("Hyperlink1");
hyperlink.NavigateUrl = map.ToUri().ToString();
```

For MVC controllers/views:

```c#
//MVC: controller contains above code to create the request
ViewBag["StaticMapUri"] = map.ToUri();

//MVC: view code
<img src="@ViewBag["StaticMapUri"]" alt="Static Map Image" />
```

You can also directly retrieve the bitmap as a byte array (`byte[]`) or as a `Stream`:

For WPF/xaml applications:
```c#
//for WPF:
BitmapImage img = new BitmapImage();
img.SourceStream = staticMapsService.GetStream(staticMapsRequest);

this.imageControl.Image = img;
```

### Using a Google Maps for Business key

```c#
//enterprise users to use your supplied information for requests.  Do this in App_Start.
GoogleSigned.AssignAllServices(new GoogleSigned("gme-your-client-id", "your-signing-key", signType: GoogleSignedType.Business));

// Then do as many requests as you like...
var request = new GeocodingRequest();
//...
var response = GeocodingService.GetResponse(request);
```

### Using a Google Maps API key

```c#
//always need to use YOUR_API_KEY for requests.  Do this in App_Start.
GoogleSigned.AssignAllServices(new GoogleSigned("your-api-key"));

// Then do as many requests as you like...
var request = new GeocodingRequest();
//...
var response = GeocodingService.GetResponse(request);
```

You can also use a particular key for a single request:

```c#
const GoogleSigned apikey = new GoogleSigned("special_api_key_here");
var request = new GeocodingRequest();
//...
var service = new GeocodingService(request, apikey);
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
