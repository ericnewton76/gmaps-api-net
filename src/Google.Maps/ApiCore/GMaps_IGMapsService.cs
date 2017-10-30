using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.ApiCore;

namespace Google.Maps.ApiCore
{
    public interface IGmapsService<TRequest, TResponse>
    {

		TResponse GetResponse(TRequest request);
    }

	
}
