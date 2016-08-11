using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Google.Maps;
using Google.Maps.DistanceMatrix;

namespace Google.Maps.Test
{
    [TestFixture]
    public class DistanceMatrixTest
    {
        [Test]
        public void DistanceMatrix()
        {
            GoogleSigned.AssignAllServices(new GoogleSigned("gme-gespsrl", "kIoQ7PBGRgsEmk5DEGd2zlw3B98="));
            var request = new DistanceMatrixRequest { Mode = TravelMode.driving };

            int i = 0;
            request.AddDestination(new Waypoint((decimal)44.496364, (decimal)11.343026));
            request.AddOrigin(new Waypoint((decimal)44.492231, (decimal)11.305164));
            request.Sensor = false;
            request.DepartureTime = (int)(DateTime.Now.AddHours(1) - new DateTime(1970, 1, 1)).TotalSeconds;
            request.TrafficModel = TrafficModel.pessimistic;

            DistanceMatrixResponse response = new DistanceMatrixService().GetResponse(request);
        }
    }
}
