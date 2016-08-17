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

using Newtonsoft.Json;
using System;

namespace Google.Maps.Shared
{
	[Serializable]
	public class AddressComponent : IEquatable<AddressComponent>
	{
		/// <summary>
		/// The full text description or name of the address component as
		/// returned by the Geocoder.
		/// </summary>
		[JsonProperty("long_name")]
		public string LongName { get; set; }

		/// <summary>
		/// An abbreviated textual name for the address component, if available.
		/// For example, an address component for the state of Alaska may have
		/// a short_name of "AK" using the 2-letter postal abbreviation.
		/// </summary>
		[JsonProperty("short_name")]
		public string ShortName { get; set; }

		/// <summary>
		/// Indicates the type of address component. This array contains a set
		/// of one or more tags.
		/// </summary>
		[JsonProperty("types")]
		public AddressType[] Types { get; set; }

		public override bool Equals(object obj)
		{
			return Equals(obj as AddressComponent);
		}
		public bool Equals(AddressComponent obj)
		{
			if(obj == null) return false;

			if(string.Compare(this.ShortName, obj.ShortName) != 0 || string.Compare(this.LongName, obj.LongName) != 0)
				return false;

			int thisTypesLength = -1, objTypesLength = -1;
			if(this.Types != null) thisTypesLength = this.Types.Length;
			if(obj.Types != null) objTypesLength = obj.Types.Length;

			try
			{
				for(int i = 0; i < objTypesLength; i++)
				{
					AddressType thisType = this.Types[i];
					AddressType objType = obj.Types[i];
					if(thisType != objType) return false;
				}
			}
			catch { return false; }

			//they seem to be equal
			return true;
		}
	}
}
