using System;
using SolarLunarName.SharedTypes.Validation;

namespace SolarLunarName.SharedTypes.Primitives
{
    public struct ValidLunarDay
    {
        private readonly int _value;

        public ValidLunarDay(int day)
        {
            Helpers.ValidateLunarDay(day);
            _value = day;
        }
        public ValidLunarDay(string day)
        {
            _value = Int32.Parse(day);
        }

        public int Value { get { return _value; } }

        public static implicit operator ValidLunarDay(int i)
        {
            return new ValidLunarDay(i);
        }

        public static implicit operator int(ValidLunarDay p)
        {
            return p.Value;
        }
        public static explicit operator ValidLunarDay(string s)
        {
            return new ValidLunarDay(s);
        }

        public static explicit operator string(ValidLunarDay p)
        {
            return p.Value.ToString();
        }

    }
}