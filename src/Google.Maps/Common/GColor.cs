using System;

namespace Google.Maps.Common
{
	/// <summary>
	/// Represents a Google Maps color.
	/// </summary>
	public struct GColor
	{
		UInt32 value;
		string colorName;

		public bool IsUndefined { get { return value == 0 && colorName == null; } }

		bool isNamedColor { get { return !String.IsNullOrEmpty(colorName); } }

		/// <summary>
		/// Returns the color as an RGB string (without an alpha channel)
		/// </summary>
		public string To24BitColorString()
		{
			if (isNamedColor) return colorName;
			return String.Format("0x{0:X6}", value >> 8);
		}

		/// <summary>
		/// Returns the color as an RGBA string
		/// </summary>
		public string To32BitColorString()
		{
			if (isNamedColor) return colorName;
			return String.Format("0x{0:X8}", value);
		}

		/// <summary>
		/// Create a color froma CSS3 color name
		/// </summary>
		public static GColor FromName(string cssColor)
		{
			var color = new GColor();
			color.colorName = cssColor.ToLower();
			return color;
		}

		/// <summary>
		/// Create a color from RGB values and a fully opaque alpha
		/// </summary>
		public static GColor FromArgb(int red, int green, int blue)
		{
			return FromArgb(255, red, green, blue);
		}

		/// <summary>
		/// Create a color from RGB and alpha values
		/// </summary>
		public static GColor FromArgb(int alpha, int red, int green, int blue)
		{
			var color = new GColor();
			color.value = (uint)(((uint)red << 24) + (green << 16) + (blue << 8) + alpha);
			return color;
		}

		public static bool operator ==(GColor a, GColor b)
		{
			if (a.isNamedColor && b.isNamedColor) return a.colorName == b.colorName;
			if (a.isNamedColor ^ b.isNamedColor) return false;
			return a.value == b.value;
		}

		public static bool operator !=(GColor a, GColor b)
		{
			return a != b;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is GColor)) return false;
			var o = (GColor)obj;
			return this == o;
		}

		public override int GetHashCode()
		{
			if (isNamedColor) return colorName.GetHashCode();
			return (int)value;
		}

#if HAS_SYSTEMDRAWING
		public static implicit operator GColor(System.Drawing.Color systemColor)
		{
			return FromArgb(systemColor.A, systemColor.R, systemColor.G, systemColor.B);
		}
#endif

	}
}