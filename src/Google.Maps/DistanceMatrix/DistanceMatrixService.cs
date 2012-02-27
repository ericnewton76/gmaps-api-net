using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Api.Maps.Service.DistanceMatrix
{
    public static class DistanceMatrixService
    {

        public static readonly Uri ApiUrl =
           new Uri("http://maps.googleapis.com/maps/api/distancematrix/");

        public static DistanceMatrixResponse GetResponse(DistanceMatrixRequest request)
        {
            var url = new Uri(ApiUrl, request.ToUri());
            Console.WriteLine(url.ToString());
            return Http.Get(url).As<DistanceMatrixResponse>();
        }//end method
    }//end class
}//end namespace
