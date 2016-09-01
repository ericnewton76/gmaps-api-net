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

        public int ToArgb()
        {
            throw new NotImplementedException();
        }
    }
}
