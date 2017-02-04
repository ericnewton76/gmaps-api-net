using System;
using System.Net;

namespace Google.Maps
{
	/// <summary>
	/// Stores a proxy information to be used with service requests to Google's APIs.
	/// </summary>
	/// <remarks>
	/// Use Proxy.AssignAllServices() method to use proxy for outgoing requests, usually during App Startup.
	/// </remarks>
	public class Proxy
	{
		/// <summary>
		/// Used by all the services
		/// </summary>
		private static IWebProxy S_proxyInstance;

		/// <summary>
		/// Gets or sets the ProxyInstance instance to use for all of the various service calls.
		/// </summary>
		public static IWebProxy ProxyInstance 
		{
			get { return S_proxyInstance; }
		}
		/// <summary>
		/// Assigns the given ProxyInstance to all services that can utilize it.
		/// </summary>
		/// <param name="proxyInstance"></param>
		public static void AssignAllServices(IWebProxy proxyInstance)
		{
			S_proxyInstance = proxyInstance;
		}
	}

}
