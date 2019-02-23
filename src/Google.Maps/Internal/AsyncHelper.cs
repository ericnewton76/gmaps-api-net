using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Maps.Internal
{
    internal class AsyncHelper
    {
		private static readonly TaskFactory _myTaskFactory = new
	 TaskFactory(CancellationToken.None, TaskCreationOptions.None,
	 TaskContinuationOptions.None, TaskScheduler.Default);

		// Microsoft.AspNet.Identity.AsyncHelper
		public static TResult RunSync<TResult>(Func<Task<TResult>> func)
		{
			CultureInfo cultureUi = CultureInfo.CurrentUICulture;
			CultureInfo culture = CultureInfo.CurrentCulture;
			return AsyncHelper._myTaskFactory.StartNew<Task<TResult>>(delegate
			{
				Thread.CurrentThread.CurrentCulture = culture;
				Thread.CurrentThread.CurrentUICulture = cultureUi;
				return func();
			}).Unwrap<TResult>().GetAwaiter().GetResult();
		}

	}
}
