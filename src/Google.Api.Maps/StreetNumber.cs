using System.Linq;
using System;

namespace Google.Api.Maps
{
    public struct StreetNumber
    {
        public static implicit operator StreetNumber(int number)
        {
            return new StreetNumber { _numbers = new[] { number } };
        }

        public static implicit operator int(StreetNumber exactStreetNumber)
        {
            return exactStreetNumber._numbers != null ? exactStreetNumber._numbers.FirstOrDefault() : 0;
        }

        public static implicit operator StreetNumber(string range)
        {
            int min = 0, max = 0;

            var numbers = range.Split('-');

            if (numbers.Length < 1 || numbers.Length > 2 || !int.TryParse(numbers[0], out min) || (numbers.Length == 2 && !int.TryParse(numbers[1], out max)))
            {
                throw new InvalidCastException("String must contain a range of two numbers separated by a dash, i.e.: 100-200.");
            }

            var array = numbers.Length == 1 ? new[] { min } : new[] { min, max };

            return new StreetNumber { _numbers = array };
        }

        public override string ToString()
        {
            string result = "0";

            if (_numbers != null && _numbers.Length > 0)
            {
                result = _numbers[0].ToString();
                if (_numbers.Length > 1)
                {
                    result += "-" + _numbers[1].ToString();
                }
            }

            return result;
        }

        private int[] _numbers;
    }
}
