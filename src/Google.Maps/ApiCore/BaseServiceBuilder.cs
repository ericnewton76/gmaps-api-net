using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Maps.ApiCore
{
	public abstract class BaseServiceBuilder<TService> : IServiceBuilder<TService>
	{

		public BaseServiceBuilder()
		{
		}

		public IHttpService HttpService { get; protected set; }
		public ISigningService SigningService { get; protected set; }
		public Uri BaseUri { get; protected set; }

		public IServiceBuilder<TService> WithHttpService(IHttpService httpService)
		{
			this.HttpService = httpService;
			return this;
		}

		public IServiceBuilder<TService> WithSigningService(ISigningService signingService)
		{
			this.SigningService = signingService;
			return this;
		}

		public abstract TService Create();
	}
}
