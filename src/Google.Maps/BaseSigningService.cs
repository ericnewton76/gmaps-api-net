using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps
{

	public abstract class BaseSigningService
	{
		private static Dictionary<Type, GoogleSigned> S_SigningInstances = new Dictionary<Type, GoogleSigned>();

		internal static void AssignSigningInstance(BaseSigningService serviceInstance, GoogleSigned signingInstance)
		{
			S_SigningInstances[serviceInstance.GetType()] = signingInstance;
		}

		protected GoogleSigned GetSigningInstance()
		{
			GoogleSigned instance;

			if(S_SigningInstances.TryGetValue(this.GetType(), out instance) == false)
				return null;
			else
				return instance;
		}

	}
}
