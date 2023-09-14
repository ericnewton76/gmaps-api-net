using System;

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
