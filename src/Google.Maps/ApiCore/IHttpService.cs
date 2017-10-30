using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.ApiCore
{
	public interface IHttpService
	{
		Task<T> GetAsync<T>(Uri uri) where T : class;

		T Get<T>(Uri uri) where T : class;

		Task<System.IO.Stream> GetStreamAsync(Uri uri);

		System.IO.Stream GetStream(Uri uri);

	}

}
