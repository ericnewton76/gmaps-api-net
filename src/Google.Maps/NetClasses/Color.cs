using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Drawing
{
    public class Color
    {
        public byte A { get; }
        public byte R { get; }
        public byte G { get; }
        public byte B { get; }
        public bool IsNamedColor { get { return false; } }
        public string Name { get; }
        public static Color Empty = null;

        public static Color Green
        {
            get
            {
                return FromArgb("#FF008000");
            }
        }
        public static Color Red
        {
            get
            {
                return FromArgb("#FFFF0000");
            }
        }

        public int ToArgb()
        {
            throw new NotImplementedException();
        }

        public static Color FromArgb(string argb)
        {
            throw new NotImplementedException();
        }

        public static Color FromArgb(int red, int green, int blue)
        {
            throw new NotImplementedException();
        }
    }
}
