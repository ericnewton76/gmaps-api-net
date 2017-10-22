using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Maps;
using Google.Maps.Geocoding;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
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

			if(System.Diagnostics.Debugger.IsAttached)
			{
				Console.WriteLine("Hit any key to end.");
				Console.ReadKey();
			}
		}



	}
}
