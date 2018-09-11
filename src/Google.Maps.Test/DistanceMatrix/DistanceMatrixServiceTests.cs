using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Google.Maps.DistanceMatrix
{
	[TestFixture]
	public class DistanceMatrixServiceTests
	{
		GoogleSigned TestingApiKey;

		DistanceMatrixService CreateService()
		{
			var svc = new DistanceMatrixService(TestingApiKey);
			return svc;
		}

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			TestingApiKey = SigningHelper.GetApiKey();
		}

		[Test]
		[Category("ValueTesting")]
		public void DrivingDistancebyLngLat()
		{
			DistanceMatrixRequest request = new DistanceMatrixRequest();
			//sheffield
			request.AddDestination(new LatLng(latitude: 53.378243m, longitude: -1.462131m));
			//rotherham
			request.AddOrigin(new LatLng(latitude: 53.434297m,longitude: -1.364678m));

			request.Mode = TravelMode.driving;

			DistanceMatrixResponse response = CreateService().GetResponse(request);

			if(response.Status == ServiceResponseStatus.OverQueryLimit)
			{
				Assert.Ignore("OverQueryLimit");
			}

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
		}

		[Test]
		[Category("ValueTesting")]
		public void DrivingDistancebyAddressAndLngLat()
		{
			DistanceMatrixRequest request = new DistanceMatrixRequest();
			//sheffield
			request.AddDestination(new Location("Sheffield"));
			//rotherham
			request.AddOrigin(new LatLng(latitude: 53.434297m, longitude: -1.364678m));

			request.Mode = TravelMode.driving;

			DistanceMatrixResponse response = CreateService().GetResponse(request);

			if(response.Status == ServiceResponseStatus.OverQueryLimit)
			{
				Assert.Ignore("OverQueryLimit");
			}

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
		}

		[Test]
		[Category("ValueTesting")]
		public void DrivingDistancebyAddress()
		{
			DistanceMatrixRequest request = new DistanceMatrixRequest();
			//sheffield
			request.AddDestination(new Location("Sheffield"));
			//rotherham
			request.AddOrigin(new Location("Rotherham"));

			request.Mode = TravelMode.driving;

			DistanceMatrixResponse response = CreateService().GetResponse(request);

			if(response.Status == ServiceResponseStatus.OverQueryLimit)
			{
				Assert.Ignore("OverQueryLimit");
			}

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
		}

		[Test]
		[Category("ValueTesting")]
		public void DrivingDistancebyLngLatHasOneOriginAndDestinationAdresses()
		{
			DistanceMatrixRequest request = new DistanceMatrixRequest();

			//rotherham
			request.AddOrigin(new LatLng(latitude: 53.434297m, longitude: -1.364678m));
			//sheffield
			request.AddDestination(new LatLng(latitude: 53.378243m, longitude: -1.462131m));

			request.Mode = TravelMode.driving;

			DistanceMatrixResponse response = CreateService().GetResponse(request);

			if(response.Status == ServiceResponseStatus.OverQueryLimit)
			{
				Assert.Ignore("OverQueryLimit");
			}

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
			Assert.AreEqual(1, response.DestinationAddresses.Length);
			Assert.AreEqual(1, response.OriginAddresses.Length);
		}

		[Test]
		[Category("ValueTesting")]
		public void DrivingDistancebyAddressHasOneOriginAndDestinationAdresses()
		{
			DistanceMatrixRequest request = new DistanceMatrixRequest();

			//rotherham
			request.AddOrigin(new Location("Rotherham"));
			//sheffield
			request.AddDestination(new Location("Sheffield"));

			request.Mode = TravelMode.driving;

			DistanceMatrixResponse response = CreateService().GetResponse(request);

			if(response.Status == ServiceResponseStatus.OverQueryLimit)
			{
				Assert.Ignore("OverQueryLimit");
			}

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
			Assert.AreEqual(1, response.DestinationAddresses.Length);
			Assert.AreEqual(1, response.OriginAddresses.Length);
		}



		[Test]
		[Category("ValueTesting")]
		public void DrivingDistancebyLngLatHasOneOriginAndMultipleDestinationAdresses()
		{
			DistanceMatrixRequest request = new DistanceMatrixRequest();

			//rotherham
			request.AddOrigin(new LatLng(latitude: 53.434297m, longitude: -1.364678m));
			//sheffield
			request.AddDestination(new LatLng(latitude: 53.378243m, longitude: -1.462131m));
			request.AddDestination(new LatLng(latitude: 51.378243m, longitude: -1.162131m));

			request.Mode = TravelMode.driving;

			DistanceMatrixResponse response = CreateService().GetResponse(request);

			if(response.Status == ServiceResponseStatus.OverQueryLimit)
			{
				Assert.Ignore("OverQueryLimit");
			}

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
			Assert.Greater(response.DestinationAddresses.Length, 1);
			Assert.AreEqual(1, response.OriginAddresses.Length, 1);
		}

		[Test]
		[Category("ValueTesting")]
		public void DrivingDistancebyAddressHasOneOriginAndMultipleDestinationAdresses()
		{
			DistanceMatrixRequest request = new DistanceMatrixRequest();

			//rotherham
			request.AddOrigin(new Location("Rotherham"));
			//sheffield
			request.AddDestination(new Location("Sheffield"));
			request.AddDestination(new Location("London"));

			request.Mode = TravelMode.driving;

			DistanceMatrixResponse response = CreateService().GetResponse(request);

			if(response.Status == ServiceResponseStatus.OverQueryLimit)
			{
				Assert.Ignore("OverQueryLimit");
			}

			Assert.AreEqual(ServiceResponseStatus.Ok, response.Status);
			Assert.Greater(response.DestinationAddresses.Length, 1);
			Assert.AreEqual(1, response.OriginAddresses.Length, 1);
		}
	}
}
