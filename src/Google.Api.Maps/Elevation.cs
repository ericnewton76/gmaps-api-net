/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Globalization;

namespace Google.Api.Maps
{
	public struct Elevation
	{
		/// <summary>
		/// Creates an Elevation object from a decimal value.
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public static implicit operator Elevation(decimal meters)
		{
			return new Elevation { _meters = meters };
		}

		/// <summary>
		/// Creates a decimal value from an Elevation object.
		/// </summary>
		/// <param name="elevation"></param>
		/// <returns></returns>
		public static implicit operator decimal(Elevation elevation)
		{
			return elevation._meters;
		}

		public Elevation(decimal meters)
			: this()
		{
			_meters = meters;
		}

		public override string ToString()
		{
			return _meters.ToString(CultureInfo.InvariantCulture);
		}

		private decimal _meters;
	}
}
