/*
 * 
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 * 
 */
using System;

namespace Google.Api.Maps.Core.StaticMaps
{
	#region Private extensions

	static class PathStyleHelperExtensions
	{
		public static bool Is24Or32bit(this string color)
		{
			return color.StartsWith("0x") && (color.Length == 8 || color.Length == 10);
		}

		public static bool Is24bit(this string color)
		{
			return color.StartsWith("0x") && color.Length == 8;
		}

		public static bool Is32bit(this string color)
		{
			return color.StartsWith("0x") && color.Length == 10;
		}

		public static string SetAlphaTransparency(this string color, byte alpha)
		{
			var newColor = color;

			if (color.Is24bit())
			{
				newColor = color + Convert.ToString(alpha, 16);
			}
			else if (color.Is32bit())
			{
				newColor = color.Remove(8, 2) + Convert.ToString(alpha, 16);
			}

			return newColor;
		}
	}

	#endregion

	public class PathStyle
	{
		// API defaults
		public static readonly byte DefaultWeight = 5;

		public byte Weight { get; set; }
		public string Color { get; set; }
		public byte AlphaTransparency
		{
			get
			{
				return Color.Is32bit()
					? Convert.ToByte(Color.Substring(8, 2), 16)
					: byte.MaxValue;
			}
			set
			{
				if (Color.Is24Or32bit())
					Color = Color.SetAlphaTransparency(value);
			}
		}
		public string FillColor { get; set; }
	}
}
