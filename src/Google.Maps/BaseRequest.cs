using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps
{
	public abstract class BaseRequest
	{
		internal abstract Uri ToUri();
	}
}
