using System;

namespace SolarLunarName.SharedTypes.Models
{
    public class SolarLunarNameModel: SolarLunarNameSimple
    {   
        
        public SolarLunarNameModel(DateTime solarDateTime, int year, int lunarMonth, int lunarDay)
            :base(year, lunarMonth, lunarDay)
        {
        SolarDateTime = solarDateTime;
        }

        public DateTime SolarDateTime { get; set; }

    }


}