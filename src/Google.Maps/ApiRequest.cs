using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Maps
{
    /// <summary>
    /// Represents the base class of all google api requests
    /// </summary>
    public abstract class ApiRequest
    {
        /// <summary>
        /// Gets the generated http-get uri for this request
        /// </summary>
        /// <returns></returns>
        public abstract Uri ToUri();

        /// <summary>
        /// Specifies whether the application requesting data is
        /// using a sensor to determine the user's location. This parameter
        /// is required for all requests.
        /// </summary>
        /// <remarks>Required.</remarks>
        /// <see cref="http://code.google.com/apis/maps/documentation/elevation/#Sensor"/>
        public bool? Sensor { get; set; }

        protected void EnsureSensor()
        {
            if (this.Sensor == null) throw new InvalidOperationException("Sensor property hasn't been set.");
        }
    }
}
