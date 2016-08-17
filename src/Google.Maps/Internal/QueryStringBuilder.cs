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

using System;

namespace Google.Maps.Internal
{
	internal class QueryStringBuilder
	{
		System.Text.StringBuilder StringBuilder { get { return this._sb; } }
		System.Text.StringBuilder _sb = new System.Text.StringBuilder();

		public override string ToString()
		{
			return _sb.ToString();
		}

		/// <summary>
		/// Appends a key/value pair when the value isn't null.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public QueryStringBuilder Append(string key, string value)
		{
			if(string.IsNullOrEmpty(value) == false)
			{
				if(_sb.Length > 0) _sb.Append("&");
				_sb.Append(key).Append("=").Append(value);
			}
			return this;
		}
		//public QueryStringBuilder Append(string key, System.Nullable<T> value)
		//{
		//    if (value != null)
		//    {
		//        if (_sb.Length > 0) _sb.Append("&");
		//        _sb.Append(key).Append("=").Append(value);
		//    }
		//    return this;
		//}

		/// <summary>
		/// Appends a value when the string isn't null.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public QueryStringBuilder Append(string value)
		{
			if(string.IsNullOrEmpty(value) == false)
			{
				if(_sb.Length > 0) _sb.Append("&");
				_sb.Append(value);
			}
			return this;
		}
	}
}
