using System;
using System.Collections.Generic;
using System.Text;

namespace SolarLunarName.Standard.Models
{
    public class SolarLunarName
    {
        public SolarLunarName(DateTime solarDateTime, int year, int lunarMonth, int lunarDay)
        {
            SolarDateTime = solarDateTime;
            Year = year;
            LunarMonth = lunarMonth;
            LunarDay = lunarDay;
        }

        public DateTime SolarDateTime { get; }
        public int Year { get; }
        public int LunarMonth { get; }
        public int LunarDay { get; }

        public override string ToString()
        {
            var stringFormat = string.Format("{0}-{1}-{2}", Year.ToString(), LunarMonth.ToString(), LunarDay.ToString());
            return stringFormat;
        }
    }
}
