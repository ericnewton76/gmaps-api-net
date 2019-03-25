using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Maps.ApiCore;

namespace Google.Maps.ApiCore
{
	public abstract class BaseGmapsService<TRequest>
		where TRequest : BaseRequest
	{
		public IHttpService HttpService { get; protected set; }
		public Uri BaseUri { get; protected set; }


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
