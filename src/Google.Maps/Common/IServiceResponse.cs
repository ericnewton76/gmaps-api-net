﻿namespace Google.Maps.Common
{
    public interface IServiceResponse
    {

		/// <summary>
		/// Contains the ServiceResponseStatus.
		/// </summary>
		ServiceResponseStatus Status { get; set; }

		/// <summary>
		/// More detailed information about the reasons behind the given status code, if other than OK.
		/// </summary>
		string ErrorMessage { get; set; }

	}
}
