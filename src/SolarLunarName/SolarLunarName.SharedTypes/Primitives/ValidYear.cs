using System;
using SolarLunarName.SharedTypes.Validation;
namespace SolarLunarName.SharedTypes.Primitives
{
    public struct ValidYear
    {
        private readonly int _value;

        public ValidYear(int year)
        {
            Helpers.ValidateYear(year);
            _value = year;
        }
        public ValidYear(string year)
        {
            _value = Int32.Parse(year);
        }

        public int Value { get { return _value; } }

        public static implicit operator ValidYear(int i)
        {
            return new ValidYear(i);
        }

        public static implicit operator int(ValidYear p)
        {
            return p.Value;
        }
        public static explicit operator ValidYear(string s)
        {
            return new ValidYear(s);
        }

        public static explicit operator string(ValidYear p)
        {
            return p.Value.ToString();
        }
        public override string ToString()
        {
            return Value.ToString();
        }

    }
}