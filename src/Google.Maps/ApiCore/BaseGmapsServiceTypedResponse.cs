using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Maps.ApiCore;

namespace Google.Maps.ApiCore
{

	public abstract class BaseGmapsServiceTypedResponse<TRequest, TResponse> :
		BaseGmapsService<TRequest>,
		IGmapsService<TRequest, TResponse>
			where TRequest : BaseRequest
			where TResponse : class
	{
		public virtual TResponse GetResponse(TRequest request)
		{
			var url = new Uri(BaseUri, request.ToUri());

			return HttpService.Get<TResponse>(url);
		}

		public async Task<TResponse> GetResponseAsync(TRequest request)
		{
			var url = new Uri(BaseUri, request.ToUri());

			return await HttpService.GetAsync<TResponse>(url);
		}

	}

}
