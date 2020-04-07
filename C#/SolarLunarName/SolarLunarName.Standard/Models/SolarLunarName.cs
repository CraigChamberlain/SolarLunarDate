using System;

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
        
        public DateTime SolarDateTime { get; set; }
        public int Year { get; set; }
        public int LunarMonth { get; set; }
        public int LunarDay { get;  set; }
    }



}