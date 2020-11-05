using System;
using SolarLunarName.SharedTypes.Validation;

namespace SolarLunarName.SharedTypes.Primitives
{
    public struct ValidLunarMonth
    {
        private readonly int _value;

        public ValidLunarMonth(int month)
        {
            Helpers.ValidateLunarMonth(month);
            _value = month;
        }
        public ValidLunarMonth(string month)
        {
            _value = Int32.Parse(month);
        }

        public int Value { get { return _value; } }

        public static implicit operator ValidLunarMonth(int i)
        {
            return new ValidLunarMonth(i);
        }

        public static implicit operator int(ValidLunarMonth p)
        {
            return p.Value;
        }
        public static explicit operator ValidLunarMonth(string s)
        {
            return new ValidLunarMonth(s);
        }

        public static explicit operator string(ValidLunarMonth p)
        {
            return p.Value.ToString();
        }

    }
}