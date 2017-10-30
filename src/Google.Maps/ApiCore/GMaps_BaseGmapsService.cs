using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.ApiCore;

namespace Google.Maps.ApiCore
{
	public abstract class BaseGmapsService<TRequest, TResponse> : IGmapsService<TRequest, TResponse>
			where TRequest : BaseRequest
			where TResponse : class
	{
		public IHttpService HttpService { get; protected set; }
		public Uri BaseUri { get; protected set; }

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

		public void Dispose()
		{
			if(HttpService != null)
			{
				var disposable = HttpService as IDisposable;
				if(disposable != null)
				{
					disposable.Dispose();
				}

				HttpService = null;
			}
		}
	}

}
