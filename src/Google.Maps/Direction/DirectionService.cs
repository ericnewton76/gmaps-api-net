using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
namespace Google.Maps.Direction
{
    public class DirectionService
    {
        public static readonly Uri ApiUrl =
            new Uri("http://maps.googleapis.com/maps/api/directions/");

        public DirectionResponse GetResponse(DirectionRequest request)
        {
            var url = new Uri(ApiUrl, request.ToUri());
            return Internal.Http.Get(url).As<DirectionResponse>();

          
        }
    }
}
