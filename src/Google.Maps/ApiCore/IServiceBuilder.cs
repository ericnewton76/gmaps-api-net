using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.ApiCore
{

	public interface IServiceBuilder<TService>
	{

		TService Create();

		IServiceBuilder<TService> WithHttpService(IHttpService httpService);

		IServiceBuilder<TService> WithSigningService(ISigningService httpService);

	}
}
