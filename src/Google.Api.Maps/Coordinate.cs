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
	public struct Coordinate
	{
		/// <summary>
		/// Creates a Coordinate object from decimal degrees.
		/// </summary>
		/// <param name="dd"></param>
		/// <returns></returns>
		public static implicit operator Coordinate(decimal decimalDegrees)
		{
			return new Coordinate { _decimalDegrees = decimalDegrees };
		}

		/// <summary>
		/// Creates a decimal value representing the decimal degrees of the
		/// Coordinate object.
		/// </summary>
		/// <param name="coordinate"></param>
		/// <returns></returns>
		public static implicit operator decimal(Coordinate coordinate)
		{
			return coordinate._decimalDegrees;
		}

		public Coordinate(decimal decimalDegrees)
		{
			_decimalDegrees = decimalDegrees;
		}

		public override string ToString()
		{
			return _decimalDegrees.ToString(CultureInfo.InvariantCulture);
		}

		private decimal _decimalDegrees;
	}
}
