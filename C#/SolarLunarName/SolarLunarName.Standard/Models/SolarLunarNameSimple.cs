using System;

namespace SolarLunarName.Standard.Models
{
    public class SolarLunarNameSimple
    {
        public SolarLunarNameSimple(int year, int lunarMonth, int lunarDay)
        {
        Year = year;
        LunarMonth = lunarMonth;
        LunarDay = lunarDay;
        }
        
        public int Year { get; set; }
        public int LunarMonth { get; set; }
        public int LunarDay { get;  set; }
    }



}