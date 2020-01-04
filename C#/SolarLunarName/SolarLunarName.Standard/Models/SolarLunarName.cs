using System;

namespace SolarLunarName.Standard.Models
{
    public class SolarLunarName: SolarLunarNameSimple
    {   
        
        public SolarLunarName(DateTime solarDateTime, int year, int lunarMonth, int lunarDay)
            :base(year, lunarMonth, lunarDay)
        {
        SolarDateTime = solarDateTime;
        }

        public DateTime SolarDateTime { get; set; }

    }


}