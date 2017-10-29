using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps.Common
{
	public abstract class BaseRequest
	{
		public abstract Uri ToUri();
	}
}
