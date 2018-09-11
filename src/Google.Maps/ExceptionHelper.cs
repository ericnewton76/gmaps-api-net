using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Maps
{
    internal static class ExceptionHelper
    {

		public static void ArgumentNull(string parameterName)
		{
			throw new ArgumentNullException(parameterName);
		}

    }
}
